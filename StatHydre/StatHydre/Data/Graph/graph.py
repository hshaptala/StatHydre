import matplotlib.pyplot as plt
import pandas as pd
import pymssql as ps
import sys
import pathlib
import scipy.stats as scp

server = 'info-mssql-etd'
username = 'etd10'
password = 'yy4hbkd6'
database = 'E10_StatHydre'

def value_request(data_type):
    return f"select T_Data_D.D_date, T_Country_CT.CT_name, T_Domain_DM.DM_label, T_Data_D.D_value from T_Data_D inner join T_DataType_DT on T_Data_D.DT_id = T_DataType_DT.DT_id left outer join T_Domain_DM on T_Data_D.DM_id = T_Domain_DM.DM_id left outer join T_Country_CT on T_Data_D.CT_id = T_Country_CT.CT_id where T_DataType_DT.DT_label = '{data_type}'"

'''
For debug purpose
'''
def zone(zone_label, username, password):
    cnxn = ps.connect ( server = server, user = username,      
                        password = password, database = database )
    df = pd.read_sql("select T_Country_CT.CT_id, T_Country_CT.CT_name from T_Country_CT inner join Belongs_to on "
                     +f"T_Country_CT.CT_id = Belongs_to.CT_id inner join T_Zone_ZN on Belongs_to.ZN_id = T_Zone_ZN.ZN_id where T_Zone_ZN.ZN_name = '{zone_label}'", cnxn, coerce_float=False)
    cnxn.close()
    return df['CT_name']

def regression(df, fig, ax):

    min = df.min().loc['D_value']
    max = df.max().loc['D_value']
    
    first = df['D_value'].iloc[0]
    last = df['D_value'].iloc[-1]

    min_length = first-min + last-min
    max_length = max-first + max-last

    df_bis = df.set_index('D_date')

    if min_length > max_length:
        cut = df_bis.idxmin()['D_value'].item()
    else :
        cut = df_bis.idxmax()['D_value'].item()
    print(cut)
    df_cuts = (df[df['D_date'] <= cut], df[df['D_date'] >= cut])
    print(df_cuts)
    for i in range (2):

        x = df_cuts[i]['D_date']
        y = df_cuts[i]['D_value']

        result= scp.linregress(x, y)
        
        df_cuts[i]['Predicted']=float(result[0])*x+float(result[1])

        df_cuts[i].plot(kind='scatter', x='D_date', y='D_value', ax=ax)
        df_cuts[i].plot(x='D_date', y='Predicted', ax=ax, color='red')
    ax.legend_ = None
 
'''
Params structure :
(Diagram type, Is stacked, Year as index, sectors involved, legend)
'''
def select_kind(data_type):
    if data_type == 'precipitation':
        return ('bar', False, False, False, 'Country')
    if data_type == 'GHG/domain' or data_type == 'energy/consump' or data_type == 'energy/prod':
        return ('pie', True, True, True, 'Domain')
    return ('line', False, True, False, 'Country')

def graphic(data_type, countries, date_range, isRegression):
    kind_params = select_kind(data_type)
    if kind_params[3] and len(countries)>1 and len(date_range)>1:
        sys.exit(1)
    if len(countries)>1 and kind_params[0]!='line':
        #Invalid params
        sys.exit(1)
    
    elif len(countries)>0:
        cnxn = ps.connect (server = server, user = username,      
                        password = password, database = database)
        df = pd.read_sql(value_request(data_type), cnxn, coerce_float=False)
        cnxn.close()
        print(df)

        fig, ax = plt.subplots()

        if not isinstance(countries, pd.Series):
            countries = pd.Series(countries, name='CT_name')

        if not isinstance(date_range, pd.Series):
            date_range = pd.Series(date_range, name='D_date')

        df_filtered = df.merge(countries, left_on='CT_name', right_on='CT_name', how='inner')
        if kind_params[2] or kind_params[3]:
            df_filtered = df_filtered.merge(date_range, left_on='D_date', right_on='D_date', how='inner')
        if isRegression:
            df_filtered = df_filtered.drop(columns=['CT_name', 'DM_label'])
            regression(df_filtered, fig, ax)
        elif kind_params[3]:
            df_filtered = df_filtered[df_filtered['CT_name']==countries[0]]
            df_filtered = df_filtered[['DM_label', 'D_value']].set_index('DM_label')
        elif kind_params[2]:
            df_filtered = df_filtered.pivot(index='D_date', columns='CT_name', values='D_value')
        else:
            df_filtered = df_filtered[['CT_name', 'D_value']].set_index('CT_name')
        if data_type=='precipitation':
            df_filtered = df_filtered.drop_duplicates()
        
        if not isRegression:
            if kind_params[0] == 'pie':
                df_filtered.plot(y='D_value', kind=kind_params[0], stacked=kind_params[1])
            else :
                df_filtered.plot(kind=kind_params[0], stacked=kind_params[1])
            plt.legend(title=kind_params[4], bbox_to_anchor=(1.1, 1.05))
        else:
            plt.legend(title='Value', bbox_to_anchor=(1.1, 1.05))
        plt.xlabel("")
        plt.ylabel("")
        
        #plt.savefig("..\..\Data\Graph\graph.png", bbox_inches='tight')
        if (isRegression):
            ax.get_legend().remove()
        plt.savefig(str(pathlib.Path(__file__).parent.resolve())+"\graph.png", bbox_inches='tight')

#Tests :

#graphic('GHG', zone('Europe', 'etd10', 'yy4hbkd6'), range(1990,2016), 'etd10', 'yy4hbkd6')
#graphic('GHG/domain', 'Italy', [2012], 'etd10', 'yy4hbkd6')

'''
Script usage :
graph data_type date_debut date_fin regression country1 country2 country3...
regression should be 1 if True, 0 if False
'''
def main():
    
    if len(sys.argv)-1 < 5:
        sys.exit(1) # Not enough params error
    elif sys.argv[2] > sys.argv[3]:
        sys.exit(1) # Invalid year
    else :
        date = range(int(sys.argv[2]), int(sys.argv[3])+1)

        countries = sys.argv[5:]
        formatted_countries = []
        for country in countries:
            c = country.replace(',', ' ')
            formatted_countries.append(c)
        regression = int(sys.argv[4])==1
        graphic(sys.argv[1], formatted_countries, date, regression)
        sys.exit(0)
        
print(sys.argv)
main()

#Ce script permet une connexion a la base SQL pour recupérer toutes les tables en 1 seul fois
import matplotlib.pyplot as plt
import pandas as pd
import pymssql

#SQL et communication avec la BD
#connexion BD
psw = 'yy4hbkd6'
cnxn = pymssql.connect ( server = 'info-mssql-etd', user = 'etd10', password = psw, database = 'E10_StatHydre' )

#Récupération tables
sql_Country = "select * from T_Country_CT"
sql_Data = "select * from T_Data_D"
sql_DataType = "select * from T_DataType_DT"
sql_Zone = "select * from T_Zone_ZN"
sql_Belongs_to = "select * from Belongs_to"

#mise sous forme de dataframe
Country_CT = pd.read_sql(sql_Country, cnxn, coerce_float=False)
#certain pays n'ont pas le bon nom donc on les changes
Country_CT = Country_CT.applymap(lambda x: x.replace("Taiwan*", "Taiwan") if isinstance(x, str) else x)
Country_CT = Country_CT.applymap(lambda x: x.replace("United States", "United States of America") if isinstance(x, str) else x)
Country_CT = Country_CT.applymap(lambda x: x.replace("Dominican Republic", "Dominican Rep.") if isinstance(x, str) else x)
Country_CT = Country_CT.applymap(lambda x: x.replace("Central African Republic", "Central African Rep.") if isinstance(x, str) else x)
Country_CT = Country_CT.applymap(lambda x: x.replace("Equatorial Guinea", "Eq. Guinea") if isinstance(x, str) else x)
Country_CT = Country_CT.applymap(lambda x: x.replace("Solomon Islands", "Solomon Is.") if isinstance(x, str) else x) 
Country_CT = Country_CT.applymap(lambda x: x.replace("Czech Republic", "Czechia") if isinstance(x, str) else x)
Country_CT = Country_CT.applymap(lambda x: x.replace("Bosnia and Herzegovina", "Bosnia and Herz.") if isinstance(x, str) else x)
Country_CT = Country_CT.applymap(lambda x: x.replace("Congo (Brazzaville)", "Dem. Rep. Congo") if isinstance(x, str) else x)
Country_CT = Country_CT.applymap(lambda x: x.replace("Ivory Coast", "Côte d'Ivoire") if isinstance(x, str) else x)
#Dans notre BD nous n'avons qu'une ligne pour le congo or dans geopandas il y en a deux donc on créer manuelement les lignes manquantes
nouvelLigne = Country_CT[Country_CT['CT_name'] == "Congo (Brazzaville)"].copy()
nouvelLigne['CT_name'] = "Congo"
Country_CT = pd.concat([Country_CT, nouvelLigne], ignore_index=True)


Data_D = pd.read_sql(sql_Data, cnxn, coerce_float=False)
DataType_DT = pd.read_sql(sql_DataType, cnxn, coerce_float=False)
Zone_ZN = pd.read_sql(sql_Zone, cnxn, coerce_float=False)
Belong_to = pd.read_sql(sql_Belongs_to, cnxn, coerce_float=False)

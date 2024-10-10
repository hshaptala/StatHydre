#Script des cartes
import geopandas as gpd
import matplotlib.pyplot as plt
import pandas as pd
import pymssql

#importation des tables
from connexionSQL import Country_CT, Data_D, DataType_DT, Zone_ZN, Belong_to
"-----------------------------------------------------------"

# Charger les données géographiques (carte du monde de base dans geopandas)
world = gpd.read_file(gpd.datasets.get_path('naturalearth_lowres'))
world_select=world[['name', 'continent', 'geometry']]

# on fait les jointures nécessaires
data_merged = Country_CT.merge(Data_D, how='left', left_on='CT_id', right_on='CT_id')
data_merged = data_merged.merge(DataType_DT, how='left', left_on='DT_id', right_on='DT_id')

def EmissionCo2(typeCarte, annee) :
    #on prend uniquement les données qui nous interesse
    data_selected = data_merged[(data_merged['D_date'] == annee) & (data_merged['DT_label'] == typeCarte)]

    #Dans notre BD, le GHG est divisé en pleins de secteurs donc pour afficher le globale on additionne tous les secteurs
    data_grouped = data_selected.groupby(['CT_name', 'DT_label', 'D_date']).agg({'D_value': 'sum'}).reset_index()

    #on fait la jointure avec le géodataframe (carte du monde)
    world_merge = world_select.merge(data_grouped, how='right', left_on='name', right_on='CT_name')

    #des donnees sont manquantes, on va donc les mettres en gris barré 
    Absentes = world.plot(color="lightgrey",
                hatch="///////",
                label="Données manquantes",
                legend = True,
                )

    #on trace la carte des émissions de CO2
    world_merge.plot(column='D_value',
                    legend=True, 
                    legend_kwds={"label":"Co2 emissions  in kilos/tonne by country for the year "+str(annee), "orientation":"horizontal"},
                        cmap="tab20b",
                        ax=Absentes)

    #-----------------------------------------------------------------------------------------------------------------
    #rajout des loc de l'entreprise
    Loc = pd.read_csv("..\\..\\Data\\Map\\implementation.csv", delimiter=',')

    # On met le dataframe Pluvio sous forme de geodataframe pour les regrouper par pays
    LocGeo = gpd.GeoDataFrame(Loc, geometry=gpd.points_from_xy(Loc.long, Loc.lat))

    #on tracer les points de localisation sur la carte
    LocGeo.plot(ax=Absentes, marker='v', color='red', markersize=50, label='Anhydre')
    # Afficher la légende
    Absentes.legend()
    
    plt.savefig('..\\..\\Data\\Map\\map.png')
    return True

def PIB_Pays(typeCarte, annee):
    #on prend uniquement les données qui nous interesse
    data_selected = data_merged[(data_merged['D_date'] == annee) & (data_merged['DT_label'] == typeCarte)]

    #on fait la jointure avec le géodataframe (carte du monde)
    world_merge = world_select.merge(data_selected, how='right', left_on='name', right_on='CT_name')

    #des donnees sont manquantes, on va donc les mettre en gris barré 
    Absentes = world.plot(color="lightgrey",
                hatch="///",
                label="Données manquantes",
                legend = True,
                )

    #on trace la carte de la pluvio
    world_merge.plot(column = 'D_value',
            legend=True,
            legend_kwds={"label":"Gross domestic product by country for the year "+str(annee), "orientation":"horizontal"},
            cmap = "viridis",
            ax=Absentes,
            )

    #-----------------------------------------------------------------------------------------------------------------
    #rajout des loc de l'entreprise
    Loc = pd.read_csv("..\\..\\Data\\Map\\implementation.csv", delimiter=',')

    # On met le dataframe Pluvio sous forme de geodataframe pour les regrouper par pays
    LocGeo = gpd.GeoDataFrame(Loc, geometry=gpd.points_from_xy(Loc.long, Loc.lat))

    #on tracer les points de localisation sur la carte
    LocGeo.plot(ax=Absentes, marker='v', color='red', markersize=50, label='Anhydre')
    # Afficher la légende
    Absentes.legend()

    plt.savefig('..\\..\\Data\\Map\\map.png')
    return True

def PluvioPays (typeCarte, annee):
    #on prend uniquement les données qui nous interesse
    data_selected = data_merged[(data_merged['D_date'] == annee) & (data_merged['DT_label'] == typeCarte)]

    #on fait la jointure avec le géodataframe (carte du monde)
    world_merge = world_select.merge(data_selected, how='right', left_on='name', right_on='CT_name')

    #des donnees sont manquantes, on va donc les mettre en gris barré 
    Absentes = world.plot(color="lightgrey",
                hatch="///",
                label="Données manquantes",
                legend = True,
                )

    #on trace la carte de la pluvio
    world_merge.plot(column = 'D_value',
            legend=True,
            legend_kwds={"label":"Pluviometry in mm by country for the year "+str(annee), "orientation":"horizontal"},
            cmap = "cividis",
            ax=Absentes,
            )

    #-----------------------------------------------------------------------------------------------------------------
    #rajout des loc de l'entreprise
    Loc = pd.read_csv("..\\..\\Data\\Map\\implementation.csv", delimiter=',')
    #print(Loc.head(5))

    # On met le dataframe Pluvio sous forme de geodataframe pour les regrouper par pays
    LocGeo = gpd.GeoDataFrame(Loc, geometry=gpd.points_from_xy(Loc.long, Loc.lat))

    #on tracer les points de localisation sur la carte
    LocGeo.plot(ax=Absentes, marker='v', color='red', markersize=50, label='Anhydre')
    # Afficher la légende
    Absentes.legend()

    plt.savefig('..\\..\\Data\\Map\\map.png')
    return True

def PopPays(TypeCarte, annee):
    #on prend uniquement les données qui nous interesse
    data_selected = data_merged[(data_merged['D_date'] == annee) & (data_merged['DT_label'] == TypeCarte)]

    #on fait la jointure avec le géodataframe (carte du monde)
    world_merge = world_select.merge(data_selected, how='right', left_on='name', right_on='CT_name')

    #des donnees sont manquantes, on va donc les mettre en gris barré 
    Absentes = world.plot(color="lightgrey",
                hatch="///",
                label="Données manquantes",
                legend = True,
                )

    #on trace la carte de la pop par pays
    world_merge.plot(column = 'D_value',
            legend=True,
            legend_kwds={"label":"Population by country for the year "+str(annee), "orientation":"horizontal"},
            cmap = "tab20c",
            ax=Absentes,
            )

    #-----------------------------------------------------------------------------------------------------------------
    #rajout des loc de l'entreprise
    Loc = pd.read_csv("..\\..\\Data\\Map\\implementation.csv", delimiter=',')

    # On met le dataframe Pluvio sous forme de geodataframe pour les regrouper par pays
    LocGeo = gpd.GeoDataFrame(Loc, geometry=gpd.points_from_xy(Loc.long, Loc.lat))

    #on tracer les points de localisation sur la carte
    LocGeo.plot(ax=Absentes, marker='v', color='red', markersize=50, label='Anhydre')
    # Afficher la légende
    Absentes.legend()

    plt.savefig('..\\..\\Data\\Map\\map.png')
    return True

def TemperaturePays(typeCarte, annee):
    #on prend uniquement les données qui nous interesse
    data_selected = data_merged[(data_merged['D_date'] == annee) & (data_merged['DT_label'] == typeCarte)]

    #on fait la jointure avec le géodataframe (carte du monde)
    world_merge = world_select.merge(data_selected, how='right', left_on='name', right_on='CT_name')

    #des donnees sont manquantes, on va donc les mettre en gris barré 
    Absentes = world.plot(color="lightgrey",
                hatch="///",
                label="Données manquantes",
                legend = True,
                )

    #on trace la carte de la temperature par pays
    world_merge.plot(column = 'D_value',
            legend=True,
            legend_kwds={"label":"Evolution of temperature in °C by country for the year "+str(annee), "orientation":"horizontal"},
            cmap = "seismic",
            ax=Absentes,
            )

    #-----------------------------------------------------------------------------------------------------------------
    #rajout des loc de l'entreprise
    Loc = pd.read_csv("..\\..\\Data\\Map\\implementation.csv", delimiter=',')

    # On met le dataframe Pluvio sous forme de geodataframe pour les regrouper par pays
    LocGeo = gpd.GeoDataFrame(Loc, geometry=gpd.points_from_xy(Loc.long, Loc.lat))

    #on tracer les points de localisation sur la carte
    LocGeo.plot(ax=Absentes, marker='v', color='red', markersize=50, label='Anhydre')
    # Afficher la légende
    Absentes.legend()

    plt.savefig('..\\..\\Data\\Map\\map.png')
    return True

def Co2Continent(typeCarte, annee):
    # on faite les jointures nécessaires
    data_merged = Country_CT.merge(Data_D, how='left', left_on='CT_id', right_on='CT_id')
    data_merged = data_merged.merge(DataType_DT, how='left', left_on='DT_id', right_on='DT_id')
    data_merged = data_merged.merge(Belong_to, how='left', left_on='CT_id', right_on='CT_id')
    data_merged = data_merged.merge(Zone_ZN, how='left', left_on='ZN_id', right_on='ZN_id')

    #on prend uniquement les données qui nous interesse
    data_selected = data_merged[(data_merged['D_date'] == annee) & (data_merged['DT_label'] == typeCarte)]

    #Dans notre BD, le GHG est divisé en pliens de secteurs donc pour afficher le globale on additionne tous les secteurs
    data_grouped = data_selected.groupby(['ZN_name', 'ZN_id'])
    data_grouped = data_grouped.agg({'D_value': 'sum'})
    data_grouped = data_grouped.reset_index()

    #on fait la jointure avec le géodataframe (carte du monde)
    world_merge = world_select.merge(data_grouped, how='right', left_on='continent', right_on='ZN_name')

    #des donnees sont manquantes, on va donc les mettre en gris barré 
    Absentes = world.plot(color="lightgrey",
                hatch="///////",
                label="Données manquantes",
                legend = True,
                )

    #on trace la carte des émissions de CO2
    world_merge.plot(column='D_value',
                    legend=True, 
                    legend_kwds={"label":"Co2 emissions in kilos/tonne by continent for year "+str(annee), "orientation":"horizontal"},
                        cmap="tab20b",
                        ax=Absentes)

    #-----------------------------------------------------------------------------------------------------------------
    #rajout des loc de l'entreprise
    Loc = pd.read_csv("..\\..\\Data\\Map\\implementation.csv", delimiter=',')

    # On met le dataframe Pluvio sous forme de geodataframe pour les regrouper par pays
    LocGeo = gpd.GeoDataFrame(Loc, geometry=gpd.points_from_xy(Loc.long, Loc.lat))

    #on tracer les points de localisation sur la carte
    LocGeo.plot(ax=Absentes, marker='v', color='red', markersize=50, label='Anhydre')
    # Afficher la légende
    Absentes.legend()

    plt.savefig('..\\..\\Data\\Map\\map.png')
    return True


import os
import sys
import argparse

# Navigate back two directories and enter the Data folder
current_dir = os.path.dirname(__file__)
data_dir = os.path.abspath(os.path.join(current_dir, '..', '..', 'Data', 'Map'))

# Add the Data folder to the system path
sys.path.append(data_dir)

# Import the modules
from ToutesLesCartes import EmissionCo2, Co2Continent, PopPays, PIB_Pays, PluvioPays, TemperaturePays


#Les options possible pour typeCarte sont : "GHG", "GDP", "precipitation", "population" et "temperature"
#Les annee vont de 1950 à 2023
def carte(typeCarte, annee, continent = False):
    if typeCarte == "GHG":
        if continent :
            Co2Continent(typeCarte, annee)
        else :
            EmissionCo2(typeCarte, annee)
    elif typeCarte=="population":
        PopPays(typeCarte, annee)
    elif typeCarte=="GDP":
        PIB_Pays(typeCarte, annee)
    elif typeCarte =="GDP/capita":
        PIB_Pays(typeCarte, annee)
    elif typeCarte=="precipitation":
        PluvioPays(typeCarte, annee)
    elif typeCarte=="temperature":
        TemperaturePays(typeCarte, annee)
    else :
        return "Pas de carte correspondante"
    return True
    
if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="Generate maps based on type and year")
    parser.add_argument("typeCarte", type=str, choices=["GHG", "GDP", "precipitation", "population", "temperature"],
                        help="Type of the map to generate")
    parser.add_argument("annee", type=int, choices=range(1950, 2023), help="Year for the map")

    args = parser.parse_args()

    # Call the function with parsed arguments
    result = carte(args.typeCarte, args.annee)

    if result is True:
        print("Map generated successfully.")
    else:
        print(result)
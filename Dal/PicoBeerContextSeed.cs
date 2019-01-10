using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PicoBeer.Domain;

namespace PicoBeer.Dal
{
    public static class PicoBeerContextSeed
    {
        private static PicoBeerContext _picoBeerContext;
        public static async Task SeedAsync(PicoBeerContext picoBeerContext)
        {
            _picoBeerContext = picoBeerContext;
            await RemoveAll();
            picoBeerContext.Malt.AddRange(getListMalt());
            picoBeerContext.Hop.AddRange(getListHop());
            picoBeerContext.Yeast.AddRange(getListYeast());
            picoBeerContext.Recipe.AddRange(getListRecipe());

            await picoBeerContext.SaveChangesAsync();
        }

        private static async Task RemoveAll()
        {
            await Remove<RecipeHop>.RemoveEntity(_picoBeerContext);
            await Remove<RecipeMalt>.RemoveEntity(_picoBeerContext);
            await Remove<RecipeYeast>.RemoveEntity(_picoBeerContext);
            await Remove<Malt>.RemoveEntity(_picoBeerContext);
            await Remove<Hop>.RemoveEntity(_picoBeerContext);
            await Remove<Yeast>.RemoveEntity(_picoBeerContext);
            await Remove<Recipe>.RemoveEntity(_picoBeerContext);
        }

        private static IEnumerable<Malt> getListMalt()
        {
            return new List<Malt>(){
                new Malt(){
                    Description = "Malt produit avec de l'orge de printemps à 2 rangs de qualité. Parfait comme malt de base pour les lagers. Favorable à la production de sucres et de proteines. Excellentes propriétés pour la filtration du moût. Donne une bière finie avec un corps et une lo (...)",
                    Name = "Pilsen 2RP",
                    Ebc = 3,
                    ExtractFactor = 80
                },
                new Malt(){
                    Description = "Produit à partir d'orge de printemps de qualité. Soigneusement grillé, il ajoute une couleur café -brun, un arome d'expresso et du corps à la bière finie. Produit des bière opaque avec un arrière goût torréfié doux, mais perceptible. Arômes: notes de café, (...)",
                    Name = "CARAFA SPECIAL I",
                    Ebc = 900,
                    ExtractFactor = 65
                }
            };
        }
        private static IEnumerable<Hop> getListHop()
        {
            return new List<Hop>(){
                new Hop(){
                    Description = "Houblon aromatique typique de Tchéquie. Est le roi indiscuté du houblon à pils. Il est le seul houblon utilisé dans la pils authentique mondiale: Pilsner Urquell. Possède un goût et un arôme doux, légèrement épicé et subtile. Ce houblon donne une amertume  (...)",
                    Name = "Saaz",
                    Alpha = 2.09,
                },
                new Hop(){
                    Description = "Utilisé dans les bières de style anglais, bières belges, stouts, porters et la plupart des Lagers",
                    Name = "East Kent Goldings",
                    Alpha = 4.25
                }
            };
        }

        private static IEnumerable<Yeast> getListYeast()
        {
            return new List<Yeast>(){
                new Yeast(){
                    Description = " Les premières Saccharomyces Carlsbergensis sous forme sèche pour de vraies bières du type Pils ! Culture d´origine Allemand (Berlin). Une levure souvent utilisé dans des brasseries de l´Europe occidentale. Fournit des bières Pils fruitées et riches en est (...)",
                    Name = "SAFLAGER S-23",
                    Attenuation = 82
                },
                new Yeast(){
                    Description = "Cette levure de Weihenstephan d´Allemagne est utilisée partout dans le monde. Il s´agit d´une levure de fermentation basse, qui garantit à la bière un goût aromatique et qui possède des qualités technologiques formidables comme une forte fermentation, un b (...)",
                    Name = "SAFLAGER W34/70",
                    Attenuation = 80
                }
            };
        }
        private static IEnumerable<Recipe> getListRecipe()
        {
            Recipe choucroute = Choucroute();

            Recipe carbonnade = new Recipe()
            {
                Description = "Brune",
                Name = "Carbonnade",
                Volume = 23,
            };

            return new List<Recipe>() { choucroute, carbonnade };

        }

        private static Recipe Choucroute()
        {
            Recipe choucroute = new Recipe()
            {
                Description = "Blonde",
                Name = "La Choucroute",
                Volume = 23
            };
            RecipeMalt choucrouteMalt1 = new RecipeMalt()
            {
                Recipe = choucroute,
                Ingredient = getListMalt().FirstOrDefault(M => M.Name == "Pilsen 2RP"),
                Quantity = 6500
            };
            RecipeMalt choucrouteMalt2 = new RecipeMalt()
            {
                Recipe = choucroute,
                Ingredient = getListMalt().FirstOrDefault(M => M.Name == "CARAFA SPECIAL I"),
                Quantity = 1000
            };
            _picoBeerContext.RecipeMalt.AddRange(choucrouteMalt1);
            _picoBeerContext.RecipeMalt.AddRange(choucrouteMalt2);
            choucroute.ListMalt.Add(choucrouteMalt1);
            choucroute.ListMalt.Add(choucrouteMalt2);
            return choucroute;
        }
    }
    public static class Remove<T> where T : BaseEntity
    {
        public static async Task RemoveEntity(PicoBeerContext picoBeerContext)
        {
            IEnumerable<T> list = picoBeerContext.Set<T>().AsEnumerable();
            picoBeerContext.RemoveRange(list);
            await picoBeerContext.SaveChangesAsync();
        }
    }
}
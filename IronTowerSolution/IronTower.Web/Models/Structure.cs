using System.Linq;

namespace IronTower.Web.Models
{
    public class Structure
    {
        public enum StructureType
        {
            Laundry,
            Restaurant,
            AmusementPark,
            Residence
        }
        public Game Game { get; set; }
        public StructureType Type { get; set; }
        public int ID { get; set; }
        public int Floor { get; set; }
        public int Income { get; set; }
        public int UpKeep { get; set; }
        public int InitialCost { get; set; }
        public int PopulationCost { get; set; }
        public bool IsResidence { get; set; }
        public int SupportedPopulation { get; set; }

        public Structure() { }

        public Structure(StructureType structureType, int _floor)
        {
        IronTowerDBContext db = new IronTowerDBContext();

         //   Game game = db.Games.FirstOrDefault();
        //    this.Game = game;

            switch (structureType)
            {
                case StructureType.Laundry:
                    this.Floor = _floor;
                    this.Income = 1;
                    this.InitialCost = 1;
                    this.IsResidence = false;
                    this.PopulationCost = 1;
                    this.SupportedPopulation = 0;
                    this.Type = StructureType.Laundry;
                    this.UpKeep = 1;
                    break;

                case StructureType.Restaurant:
                    this.Floor = _floor;
                    this.Income = 2;
                    this.InitialCost = 1;
                    this.IsResidence = false;
                    this.PopulationCost = 3;
                    this.SupportedPopulation = 0;
                    this.Type = StructureType.Restaurant;
                    this.UpKeep = 1;
                    break;

                case StructureType.AmusementPark:
                    this.Floor = _floor;
                    this.Income = 3;
                    this.InitialCost = 3;
                    this.IsResidence = false;
                    this.PopulationCost = 1;
                    this.SupportedPopulation = 0;
                    this.Type = StructureType.AmusementPark;
                    this.UpKeep = 1;
                    break;

                case StructureType.Residence:
                    this.Floor = _floor;
                    this.Income = 0;
                    this.InitialCost = 1;
                    this.IsResidence = true;
                    this.PopulationCost = 0;
                    this.SupportedPopulation = 5;
                    this.Type = StructureType.Residence;
                    this.UpKeep = 1;
                    break;

                default:
                    break;
            }
        }
    }
}
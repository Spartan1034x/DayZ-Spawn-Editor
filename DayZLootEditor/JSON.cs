using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DayZLootEditor
{
    

    public class AttachmentSlotItemSet
    {
        public string slotName { get; set; }
        public List<DiscreteItemSet> discreteItemSets { get; set; }

        public AttachmentSlotItemSet(string SlotName, List<DiscreteItemSet> DiscreteItemSets) 
        {
            slotName = SlotName;
            discreteItemSets = DiscreteItemSets;
        }
    }

    public class Attributes
    {
       
        public double healthMin { get; set; }
        public double healthMax { get; set; }
        public double quantityMin { get; set; }
        public double quantityMax { get; set; }

        public Attributes()
        {
            // Set default values for all double properties
            healthMin = 1.0;
            healthMax = 1.0;
            quantityMin = 1.0;
            quantityMax = 1.0;
        }
    }

    public class ComplexChildrenType
    {
        public string itemType { get; set; }
        public Attributes attributes { get; set; }
        public int quickBarSlot { get; set; }
        public bool? simpleChildrenUseDefaultAttributes { get; set; }
        public List<string> simpleChildrenTypes { get; set; }
        public List<ComplexChildrenType> complexChildrenTypes { get; set; }

        //constructor
        public ComplexChildrenType(string ItemType, List<ComplexChildrenType> ComplexChildrenList)
        {
            itemType = ItemType;
            attributes = new Attributes();
            quickBarSlot = -1;
            simpleChildrenUseDefaultAttributes = false;
            simpleChildrenTypes = new List<string>();
            complexChildrenTypes = ComplexChildrenList;
        }
        //constructor
        public ComplexChildrenType(string ItemType, int QuickbarSlot, List<ComplexChildrenType> ComplexChildrenList)
        {
            itemType = ItemType;
            attributes = new Attributes();
            quickBarSlot = QuickbarSlot;
            simpleChildrenUseDefaultAttributes = false;
            simpleChildrenTypes = new List<string>();
            complexChildrenTypes = ComplexChildrenList;
        }

        //Constructor takes in Itemtype and simple child
        public ComplexChildrenType(string ItemType, List<String> SimpleChildren)
        {
            itemType = ItemType;
            attributes = new Attributes();  // Set default values for attributes
            quickBarSlot = -1;  // Set default value for quickBarSlot
            simpleChildrenUseDefaultAttributes = false;
            simpleChildrenTypes = SimpleChildren;
            complexChildrenTypes = new List<ComplexChildrenType>();
        }

        //Constructor that takes in itemtype and hotslot number
        public ComplexChildrenType(string ItemType, int QuickbarSlot)
        {
            itemType = ItemType;
            attributes = new Attributes();  // Set default values for attributes
            quickBarSlot = QuickbarSlot;  // Set default value for quickBarSlot
            simpleChildrenUseDefaultAttributes = false;
            simpleChildrenTypes = new List<string>();
            complexChildrenTypes = new List<ComplexChildrenType>();
        }

        //Constructor takes only itemType, defaults everything else
        public ComplexChildrenType(string ItemType)
        {
            itemType = ItemType;
            attributes = new Attributes();  // Set default values for attributes
            quickBarSlot = -1;  // Set default value for quickBarSlot
            simpleChildrenUseDefaultAttributes = false;
            simpleChildrenTypes = new List<string>();
            complexChildrenTypes = new List<ComplexChildrenType>();
        }

    }

    public class DiscreteItemSet
    {
        public string itemType { get; set; }
        public int spawnWeight { get; set; }
        public Attributes attributes { get; set; }
        public int quickBarSlot { get; set; }
        public List<ComplexChildrenType> complexChildrenTypes { get; set; }
        public bool simpleChildrenUseDefaultAttributes { get; set; }
        public List<string> simpleChildrenTypes { get; set; }

        public DiscreteItemSet(string ItemType)
        {
            itemType = ItemType;
            spawnWeight = 1;
            attributes = new Attributes();
            quickBarSlot = -1;
            complexChildrenTypes = new List<ComplexChildrenType>();
            simpleChildrenUseDefaultAttributes = false;
            simpleChildrenTypes = new List<string>();
        }

        public DiscreteItemSet(string ItemType, List<string> SimpleChildrenTypes)
        {
            itemType = ItemType;
            spawnWeight = 1;
            attributes = new Attributes();
            quickBarSlot = -1;
            complexChildrenTypes = new List<ComplexChildrenType>();
            simpleChildrenUseDefaultAttributes = false;
            simpleChildrenTypes = SimpleChildrenTypes;
        }

        public DiscreteItemSet(string ItemType, List<ComplexChildrenType> ComplexChildList) 
        {
            itemType= ItemType;
            spawnWeight = 1;
            attributes = new Attributes();
            quickBarSlot= -1;
            complexChildrenTypes= ComplexChildList;
            simpleChildrenUseDefaultAttributes = false;
            simpleChildrenTypes = new List<string>();
        }

        public DiscreteItemSet(string ItemType, int QuickbarSlot, List<ComplexChildrenType> ComplexChildList, List<string> SimpleChildrenTypes)
        {
            itemType = ItemType;
            spawnWeight = 1;
            attributes = new Attributes();
            quickBarSlot = QuickbarSlot;
            complexChildrenTypes = ComplexChildList;
            simpleChildrenUseDefaultAttributes = false;
            simpleChildrenTypes = SimpleChildrenTypes;
        }
    }

    public class DiscreteUnsortedItemSet
    {
        public string name { get; set; }
        public int spawnWeight { get; set; }
        public Attributes attributes { get; set; }
        public List<ComplexChildrenType> complexChildrenTypes { get; set; }
        public bool simpleChildrenUseDefaultAttributes { get; set; }
        public List<string> simpleChildrenTypes { get; set; }

        public DiscreteUnsortedItemSet (string Name, List<ComplexChildrenType> ComplexChildrenTypes, List<string> SimpleChildrenTypes)
        {
            name = Name;
            spawnWeight = 1;
            attributes= new Attributes();
            complexChildrenTypes = ComplexChildrenTypes;
            simpleChildrenUseDefaultAttributes = false;
            simpleChildrenTypes = SimpleChildrenTypes;

        }
    }

    public class Root
    {
        public int spawnWeight { get; set; }
        public string name { get; set; }
        public List<string> characterTypes { get; set; } = new List<string>();
        public List<AttachmentSlotItemSet> attachmentSlotItemSets { get; set; } = new List<AttachmentSlotItemSet>();
        public List<DiscreteUnsortedItemSet> discreteUnsortedItemSets { get; set; } = new List<DiscreteUnsortedItemSet>();

        public Root(int SpawnWeight, string Name, List<AttachmentSlotItemSet> AttachementSlotItemSetUser, List<DiscreteUnsortedItemSet> DiscreteUnsortedItemSetUser)  
        {
            spawnWeight = SpawnWeight;
            name = Name;
            characterTypes = new List<string> {"SurvivorM_Mirek",
      "SurvivorM_Boris",
      "SurvivorM_Cyril",
      "SurvivorM_Denis",
      "SurvivorM_Elias",
      "SurvivorM_Francis",
      "SurvivorM_Guo",
      "SurvivorM_Hassan",
      "SurvivorM_Indar",
      "SurvivorM_Jose",
      "SurvivorM_Kaito",
      "SurvivorM_Lewis",
      "SurvivorM_Manua",
      "SurvivorM_Niki",
      "SurvivorM_Oliver",
      "SurvivorM_Peter",
      "SurvivorM_Quinn",
      "SurvivorM_Rolf",
      "SurvivorM_Seth",
      "SurvivorM_Taiki",
      "SurvivorF_Eva",
      "SurvivorF_Frida",
      "SurvivorF_Gabi",
      "SurvivorF_Helga",
      "SurvivorF_Irena",
      "SurvivorF_Judy",
      "SurvivorF_Keiko",
      "SurvivorF_Linda",
      "SurvivorF_Maria",
      "SurvivorF_Naomi",
      "SurvivorF_Baty" };
            attachmentSlotItemSets = AttachementSlotItemSetUser;
            discreteUnsortedItemSets = DiscreteUnsortedItemSetUser;
        }
    }

}

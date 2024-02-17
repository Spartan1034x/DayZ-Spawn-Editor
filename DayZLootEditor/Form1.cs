using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DayZLootEditor
{
    public partial class frmMain : Form
    {

        //creates an update list based on user selection from the edit form
        private static List<ComplexChildrenType> userInventoryListComplexChildren = new List<ComplexChildrenType>();
        private static List<String> userInventoryListSimpleChildren = new List<String>();

        //Weapon Arrays
        private static string[] sights = PopulateArray("Sights.txt");
        private static string[] weaponBack = PopulateArray("Weapons.txt");
        private static string[] weaponLight = { "", "UniversalLight" };
        private static string[] weaponAttachment = PopulateArray("Attachments.txt");
        private static string[] magDisplay = PopulateArray("MagsDisplay.txt");//parrallel arrays index can be matched to give proper code names when creating object, and seperate ones to display
        private static string[] magCode = PopulateArray("Mags.txt"); //Confirmed size is the same originally weaponMagsCode switched for testing

        //Vest Arrays
        private static string[] vests = PopulateArray("Vests.txt");
        private static string[] pouches = PopulateArray("Pouches.txt");
        private static string[] holsters = PopulateArray("Holsters.txt");

        //Shirts array
        private static string[] shirts = PopulateArray("Shirts.txt");

        //Belt arrays
        private static string[] belts = PopulateArray("Belts.txt");
        private static string[] knives = PopulateArray("Knives.txt");
        private static string[] pistols = PopulateArray("Pistol.txt");

        //Pants array
        private static string[] pants = PopulateArray("Pants.txt");

        //Bags array
        private static string[] bags = PopulateArray("Bags.txt");

        //face array
        private static string[] face = PopulateArray("Face.txt");

        //eyewear array
        private static string[] eyes = PopulateArray("Eyes.txt");

        //hands array
        private static string[] gloves = PopulateArray("Hands.txt");

        //boots array
        private string[] boots = PopulateArray("Boots.txt");

        //Calls ftn to populate armband array
        private string[] armbands = PopulateArray("Armbands.txt");

        //Calls ftn to populate helmet array
        private string[] helmets = PopulateArray("Helmets.txt");

        //Sent: String (file name)
        //Return: String Array of item names
        //Description: Reads inventory item txt file from folder, then places into array
        private static string[] PopulateArray(string filePath)
        {
            //MessageBox.Show(Convert.ToString(helmets1.Length));
            string folderPath = "ItemSets/" + filePath;
            string[] lines;
            if (File.Exists(folderPath))
            {
                lines = File.ReadAllLines(folderPath);
                return lines;
            }
            else
            {
                MessageBox.Show("File path for \"" + folderPath + "\" not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new string[0]; // Return an empty array in case of failure
            }
        }

        //enters data into all cmb boxes
        private void InitializeComboBox()
        {
            //stes cmb for helmets
            cmbHelmetMain.Items.AddRange(helmets);

            //sets cmb armbands
            cmbArmbandMain.Items.AddRange(armbands);

            //sets cmb for boots
            cmbFeetMain.Items.AddRange(boots);
            cmbFeetKnife.Items.AddRange(knives);

            //sets cmb for hands
            cmbGlovesMain.Items.AddRange(gloves);

            //sets cmb for eyes
            cmbEyeWearMain.Items.AddRange(eyes);

            //sets cmb for face
            cmbFaceMain.Items.AddRange(face);

            //sets cmb for bags
            cmbBackMain.Items.AddRange(bags);

            //sets cmb for pants
            cmbPantsMain.Items.AddRange(pants);

            //sets cmb data for belt cmbs
            cmbBeltMain.Items.AddRange(belts);
            cmbBeltKnife.Items.AddRange(knives);
            cmbBeltHolster.Items.AddRange(holsters);
            cmbBeltPistol.Items.AddRange(pistols);


            //sets cmb data for shirts
            cmbShirtMain.Items.AddRange(shirts);

            //sets cmd data for vest cmbs
            cmbVestMain.Items.AddRange(vests);
            cmbVest2.Items.AddRange(pouches);
            cmbVest3.Items.AddRange(holsters);

            //sets cmb data for Hands cmbs
            cmbHandMain.Items.AddRange(weaponBack);
            cmbHandSight.Items.AddRange(sights);
            cmbHandMag.Items.AddRange(magDisplay);
            cmbHandLight.Items.AddRange(weaponLight);
            cmbHand4.Items.AddRange(weaponAttachment);
            cmbHand5.Items.AddRange(weaponAttachment);
            cmbHand6.Items.AddRange(weaponAttachment);
            cmbHand7.Items.AddRange(weaponAttachment);

            //sets combo data for RS cmbs
            cmbRSMain.Items.AddRange(weaponBack);
            cmbRSSight.Items.AddRange(sights);
            cmbRSMag.Items.AddRange(magDisplay);
            cmbRSLight.Items.AddRange(weaponLight);
            cmbRS4.Items.AddRange(weaponAttachment);
            cmbRS5.Items.AddRange(weaponAttachment);
            cmbRS6.Items.AddRange(weaponAttachment);
            cmbRS7.Items.AddRange(weaponAttachment);

            // Set the combo box data source to the list for LS Slot
            cmbLSMain.Items.AddRange(weaponBack);
            cmbLSSight.Items.AddRange(sights);
            cmbLSLight.Items.AddRange(weaponLight);
            cmbLS3.Items.AddRange(magDisplay);
            cmbLS4.Items.AddRange(weaponAttachment);
            cmbLS5.Items.AddRange(weaponAttachment);
            cmbLS6.Items.AddRange(weaponAttachment);
            cmbLS7.Items.AddRange(weaponAttachment);


        }

        public frmMain()
        {
            InitializeComponent();

        }

        //Creates new instance of edit form so edit form ftns can be called throughout
        frmEdit frmEdit = new frmEdit();

        private void frmMain_Load(object sender, EventArgs e)
        {
            //initializes combo boxes with lists
            InitializeComboBox();

            //initializes every cmb to index 0, so value is ""
            foreach (System.Windows.Forms.ComboBox comboBox in Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                comboBox.SelectedIndex = 0;
            }
            
        }

        //Sets all combo box to first index which is blank, and all nuds to default, hides all inventory displays, unchecks all rads
        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (System.Windows.Forms.ComboBox comboBox in Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                if (comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = 0;
            }
            txtLoadoutName.Text = "Loadout1";
            nudSpawnChance.Value = 1;
            lblInventoryBuilt.Visible = false;
            picCheckMark.Visible = false;
            lblWarning.Visible = true;
            picWarning.Visible = true;
            userInventoryListComplexChildren.Clear();//clears user list
            userInventoryListSimpleChildren.Clear();//clears user list
            frmEdit.TriggerResetButtonClick();//triggers reset btn click event in edit form
            radWest.Checked = false;
            radEast.Checked = false;
            radBlack.Checked = false;
            radCamo.Checked = false;
        }

        //Opens Edit form, creates new userInventoryListComplexChildren by calling ftn in editForm, changes some control properties
        private void btnInventory_Click(object sender, EventArgs e)
        {
            //clears all indicators
            lblWarning.Visible = false;
            picWarning.Visible = false;
            lblInventoryBuilt.Visible = false;
            picCheckMark.Visible = false;

            //if ok was clicked then excute this code
            if (frmEdit.ShowDialog() == DialogResult.OK)
            {
                ReceiveEditFormData();
            }
            else
            {
                ReceiveEditFormData();
            }
        }

        private void ReceiveEditFormData()
        {
            //Receives lists from edit form and places them in list in this form (inherently clears the lists first so no worry of double lists)
            userInventoryListComplexChildren = frmEdit.UserEditedComplexChildrenList();
            userInventoryListSimpleChildren = frmEdit.UserEditedSimpleChildrenList();

            //If lists have items shows checkmark, and changes button text to edit
            if (userInventoryListComplexChildren.Count > 0 || userInventoryListSimpleChildren.Count > 0)
            {
                lblWarning.Visible = false;
                picWarning.Visible = false;
                lblInventoryBuilt.Visible = true;
                picCheckMark.Visible = true;
            }
            else
            {
                lblInventoryBuilt.Visible = false;
                picCheckMark.Visible = false;
                lblWarning.Visible = true;
                picWarning.Visible = true;
            }
        }



        //only allows placement of plate car attatchments on plat car
        private void cmbVestMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVestMain.SelectedIndex == 1 || cmbVestMain.SelectedIndex == 2 || cmbVestMain.SelectedIndex == 3 || cmbVestMain.SelectedIndex == 4)
            { cmbVest2.Enabled = true;
                cmbVest3.Enabled = true;
            }
            else 
            {
                cmbVest2.SelectedIndex = 0; cmbVest3.SelectedIndex = 0;
                cmbVest2.Enabled = false; cmbVest3.Enabled = false; }
            }

        //Allows batterries to only be placed in sights that accept
        private void cmbLSSight_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (new[] { 6, 7, 9, 10, 11, 12, 14, 15 }.Contains(cmbLSSight.SelectedIndex)) 
            { 
                chkBatLSSight.Checked = true;
                chkBatLSSight.Enabled = true;
            }
            else if (new[] { 6, 7, 9, 10, 11, 12, 14, 15 }.Contains(cmbLSSight.SelectedIndex))
            {
            }
            else 
            {
                chkBatLSSight.Checked=false;
                chkBatLSSight.Enabled=false;
            }
        }

        //Allows batterries to only be placed in sights that accept
        private void cmbRSSight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (new[] { 6, 7, 9, 10, 11, 12, 14, 15 }.Contains(cmbRSSight.SelectedIndex))
            {
                chkRSSight.Checked = true;
                chkRSSight.Enabled = true;
            }
            else if (new[] { 6, 7, 9, 10, 11, 12, 14, 15 }.Contains(cmbRSSight.SelectedIndex))
            {
            }
            else
            {
                chkRSSight.Checked = false;
                chkRSSight.Enabled = false;
            }
        }

        //Allows batterries to only be placed in sights that accept
        private void cmbHandSight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (new[] { 6, 7, 9, 10, 11, 12, 14, 15 }.Contains(cmbHandSight.SelectedIndex))
            {
                chkHandsSight.Checked = true;
                chkHandsSight.Enabled = true;
            }
            else if (new[] { 6, 7, 9, 10, 11, 12, 14, 15 }.Contains(cmbHandSight.SelectedIndex))
            {
            }
            else
            {
                chkHandsSight.Checked = false;
                chkHandsSight.Enabled = false;
            }
        }

        //checks bat if user selects universal light
        private void cmbLSLight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLSLight.SelectedIndex == 1)
            {
                chkBatLSLight.Enabled = true;
                chkBatLSLight.Checked = true;
            }
            else
            {
                chkBatLSLight.Checked = false;
                chkBatLSLight.Enabled = false;
            }
        }

        //checks bat if user selects universal light
        private void cmbRSLight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRSLight.SelectedIndex == 1)
            {
                chkRSLight.Enabled = true;
                chkRSLight.Checked = true;
            }
            else
            {
                chkRSLight.Checked = false;
                chkRSLight.Enabled = false;
            }
        }

        //checks bat if user selects universal light
        private void cmbHandLight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHandLight.SelectedIndex == 1)
            {
                chkHandsLight.Enabled = true;
                chkHandsLight.Checked = true;
            }
            else
            {
                chkHandsLight.Checked= false;
                chkHandsLight.Enabled= false;
            }
        }

        //checks eyewearnods box is user selects nvg headstrap
        private void cmbEyeWearMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEyeWearMain.SelectedIndex == 3)
            {
                chkEyeWearNods.Enabled = true;
                chkEyeWearNods.Checked = true;
            }
            else
            {
                chkEyeWearNods.Checked= false;
                chkEyeWearNods.Enabled= false;
            }
        }

        //checks nods and tac light if user selects tac helm
        private void cmbHelmetMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHelmetMain.SelectedIndex == 34)
            {
                chkHelmetNods.Enabled = true;
                chkHelmetLight.Enabled = true;
                chkHelmetLight.Checked = true;
                chkHelmetNods.Checked = true;
            }
            else
            {
                chkHelmetLight.Checked= false;
                chkHelmetNods.Checked= false;
                chkHelmetLight.Enabled= false;
                chkHelmetNods.Enabled= false;
            }
        }

        //Belt selections, right now just rope belt error checking
        private void cmbBeltMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if rope belt is selected knife cmb set to nothing and disabled, ropeknife chk visible and checked, if deselected selection reset
            if ( cmbBeltMain.SelectedIndex == 6)
            {
                chkBeltRopeKnife.Visible = true;
                chkBeltRopeKnife.Checked = true;
                nudHSBeltKnife.Enabled = true;
                chkBeltCanteen.Checked = false;
                chkBeltCanteen.Enabled= false;
                cmbBeltKnife.SelectedIndex = 0;
                cmbBeltKnife.Enabled= false;
                cmbBeltHolster.SelectedIndex = 0;
                cmbBeltHolster.Enabled= false;
            }
            else if ( cmbBeltMain.SelectedIndex != 0 && cmbBeltMain.SelectedIndex != 6)
            {
                chkBeltRopeKnife.Checked= false;
                chkBeltRopeKnife.Visible= false;
                cmbBeltKnife.Enabled = true;
                cmbBeltHolster.Enabled = true;
                chkBeltCanteen.Enabled = true;
                chkBeltCanteen.Checked= true;
            }
            else
            {
                chkBeltCanteen.Checked = false;
                chkBeltCanteen.Enabled= false;
                cmbBeltKnife.SelectedIndex = 0;
                cmbBeltKnife.Enabled= false;
                cmbBeltHolster.SelectedIndex = 0;
                cmbBeltHolster.Enabled= false;
                chkBeltRopeKnife.Checked = false;
                chkBeltRopeKnife.Visible = false;
                nudHSBeltKnife.Value = -1;
                nudHSBeltKnife.Enabled = false;
            }

        }

        //only allows pistolSelection selection once holster selction on belt has been made
        private void cmbBeltHolster_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBeltHolster.SelectedIndex != 0)
            {
                cmbBeltPistol.Enabled=true;
            }
            else
            {
                cmbBeltPistol.SelectedIndex = 0;
                cmbBeltPistol.Enabled = false;
            }
        }

        //user selction limitations for beltpistol
        private void cmbBeltPistol_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cz75, fx45, glock
            if (new[] { 1, 6, 7 }.Contains(cmbBeltPistol.SelectedIndex))
            {
                nudHSBeltPistol.Enabled = true;
                chkBeltMag.Enabled = true;
                chkBeltLight.Enabled = true;
                chkBeltRDS.Enabled = true;
                chkBeltSup.Enabled=true;
            }
            //1911
            else if (new[] { 2, 5}.Contains(cmbBeltPistol.SelectedIndex))
            {
                nudHSBeltPistol.Enabled = true;
                chkBeltSup.Enabled = true;
                chkBeltMag.Enabled = true;
                chkBeltLight.Enabled = true;
                chkBeltRDS.Enabled = false;
            }
            //deagle
            else if (new[] {3, 4}.Contains(cmbBeltPistol.SelectedIndex))
            {
                nudHSBeltPistol.Enabled = true;
                chkBeltRDS.Enabled = true;
                chkBeltSup.Enabled = true;
                chkBeltMag.Enabled = true;
                chkBeltLight.Enabled = false;
            }
            //u-70
            else if (cmbBeltPistol.SelectedIndex == 9) 
            {
                nudHSBeltPistol.Enabled = true;
                chkBeltSup.Enabled = true;
                chkBeltMag.Enabled = true;
                chkBeltLight.Enabled = false;
                chkBeltRDS.Enabled = false;

            }
            //mk11
            else if (cmbBeltPistol.SelectedIndex == 11 || cmbBeltPistol.SelectedIndex == 10)
            {
                nudHSBeltPistol.Enabled = true;
                chkBeltSup.Enabled = false;
                chkBeltMag.Enabled = true;
                chkBeltLight.Enabled = false;
                chkBeltRDS.Enabled = false;
            }
            //if nothing selected HS -1 and disabled chk
            else if (cmbBeltPistol.SelectedIndex == 0)
            {
                nudHSBeltPistol.Value = -1;
                nudHSBeltPistol.Enabled = false;
                chkBeltLight.Checked = false;
                chkBeltRDS.Checked = false;
                chkBeltMag.Checked = false;
                chkBeltSup.Checked = false;
                chkBeltMag.Enabled=false;
                chkBeltLight.Enabled=false;
                chkBeltRDS.Enabled=false;
                chkBeltSup.Enabled=false;
            }
            //all others
            else
            {
                nudHSBeltPistol.Enabled = true;
                chkBeltRDS.Checked = false;
                chkBeltSup.Checked = false;
                chkBeltMag.Checked = false;
                chkBeltLight.Checked = false;
                chkBeltRDS.Enabled = false;
                chkBeltSup.Enabled = false;
                chkBeltMag.Enabled = false;
                chkBeltLight.Enabled = false;
            }
        }
        
        //limitsselection for backpack addons
        private void cmbBackMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBackMain.SelectedIndex != 0)
            {
                radGlowstick.Enabled = true;
                radGPS.Enabled = true;
                radRadio.Enabled = true;
            }
            else
            {
                radGlowstick.Checked = false;
                radGPS.Checked = false;
                radRadio.Checked = false;
                radGlowstick.Enabled = false;
                radGPS.Enabled = false;
                radRadio.Enabled = false;
            }
        }
        
        //limits knife selection feet
        private void cmbFeetMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (new[] { 37, 38, 39, 40, 41 }.Contains(cmbFeetMain.SelectedIndex))
            {
                cmbFeetKnife.Enabled=true;
            }
            else
            {
                cmbFeetKnife.SelectedIndex = 0;
                cmbFeetKnife.Enabled=false;
                nudHSFeetKnife.Value = -1;
                nudHSFeetKnife.Enabled = false;
            }
        }

        //enables/disables beltknife 
        private void cmbBeltKnife_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBeltKnife.SelectedIndex != 0)
            {
                nudHSBeltKnife.Enabled = true;
            }
            else
            {
                nudHSBeltKnife.Value = -1;
                nudHSBeltKnife.Enabled=false;
            }
        }

        //enables feetknife hs if knife selected
        private void cmbFeetKnife_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFeetKnife.SelectedIndex != 0)
            {
                nudHSFeetKnife.Enabled=true;
            }
            else
            {
                nudHSFeetKnife.Value = -1;
                nudHSFeetKnife.Enabled = false;
            }
        }

        //enables LS cmbs only if weapon is selected, if nothing then back to defaults
        private void cmbLSMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLSMain.SelectedIndex != 0)
            {
                nudHSLeftShoulder.Enabled = true;
                cmbLS3.Enabled = true;
                cmbLS4.Enabled = true;
                cmbLS5.Enabled = true;
                cmbLS6.Enabled = true;
                cmbLS7.Enabled = true;
                cmbLSLight.Enabled = true;
                cmbLSSight.Enabled=true;
            }
            else
            {
                cmbLS3.SelectedIndex = 0;
                cmbLS4.SelectedIndex = 0;
                cmbLS5.SelectedIndex = 0;
                cmbLS6.SelectedIndex = 0;
                cmbLS7.SelectedIndex = 0;
                cmbLSLight.SelectedIndex = 0;
                cmbLSSight.SelectedIndex = 0;
                cmbLS3.Enabled=false;
                cmbLS4.Enabled=false;
                cmbLS5.Enabled=false;
                cmbLS6.Enabled=false;
                cmbLS7.Enabled=false;
                cmbLSLight.Enabled=false;
                cmbLSSight.Enabled=false;
                nudHSLeftShoulder.Value = -1;
                nudHSLeftShoulder.Enabled=false;
            }
        }

        //enables RS cmbs only if weapon is selected, if nothing then back to defaults
        private void cmbRSMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRSMain.SelectedIndex != 0)
            {
                nudHSRightShoulder.Enabled = true;
                cmbRSMain.Enabled = true;
                cmbRS4.Enabled = true;
                cmbRS5.Enabled = true;
                cmbRS6.Enabled=true;
                cmbRS7.Enabled=true;
                cmbRSLight.Enabled=true;
                cmbRSSight.Enabled=true;
                cmbRSMag.Enabled=true;
            }
            else
            {
                cmbRS4.SelectedIndex = 0;  
                cmbRS5.SelectedIndex = 0;
                cmbRS6.SelectedIndex = 0;
                cmbRS7.SelectedIndex = 0;
                cmbRSLight.SelectedIndex = 0;
                cmbRSSight.SelectedIndex = 0;
                cmbRSMag.SelectedIndex = 0;
                cmbRS6.Enabled=false;
                cmbRS7.Enabled=false;
                cmbRS4.Enabled=false;
                cmbRS5.Enabled=false;
                cmbRSSight.Enabled=false;
                cmbRSMag.Enabled=false;
                cmbRSLight.Enabled = false;
                nudHSRightShoulder.Value = -1;
                nudHSRightShoulder.Enabled=false;
            }
        }

        //enables Hand cmbs only if weapon is selected, if nothing then back to defaults
        private void cmbHandMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbHandMain.SelectedIndex != 0)
            {
                nudHSHands.Enabled = true;
                cmbHandMain.Enabled=true;
                cmbHandLight.Enabled=true;
                cmbHandSight.Enabled=true;
                cmbHandMag.Enabled=true;
                cmbHand4.Enabled=true;
                cmbHand5.Enabled=true;
                cmbHand6.Enabled=true;
                cmbHand7.Enabled=true;
            }
            else
            {
                nudHSHands.Value = -1;
                cmbHandMag.SelectedIndex = 0;
                cmbHandLight.SelectedIndex = 0;
                cmbHandSight.SelectedIndex = 0;
                cmbHand4.SelectedIndex = 0;
                cmbHand5.SelectedIndex = 0;
                cmbHand6.SelectedIndex = 0;
                cmbHand7.SelectedIndex = 0;
                nudHSHands.Enabled = false;
                cmbHandLight.Enabled = false;
                cmbHandSight.Enabled=false;
                cmbHandMag.Enabled=false;
                cmbHand4.Enabled = false;
                cmbHand5.Enabled=false;
                cmbHand6.Enabled = false;
                cmbHand7.Enabled = false;
            }
        }

        //class variable for battery simplechild, makes easier to send in list everytime
        private static List<string> bat9V = new List<string> { "Battery9V" };

        private void btnCreateJSON_Click(object sender, EventArgs e)
        {            
            //If inventory is empty display a messagebox
            if (userInventoryListComplexChildren.Count == 0 && userInventoryListSimpleChildren.Count ==0)
            {
                MessageBox.Show("Inventory is Empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            AttachmentSlotItemSet Hips = CreateHips();//Calls create hips function, returns the Hips object for AttachmentSlotItems

            AttachmentSlotItemSet Body = CreateBody();//Calls create body function, returns body object for AttachmentSlotItems

            AttachmentSlotItemSet Legs = CreateLegs();//Calls create legs function, returns leg object for AttachmentSlotItems
            
            AttachmentSlotItemSet Back = CreateBack();//Calls create back function, returns back object for AttachmentSlotItems

            AttachmentSlotItemSet Vest = CreateVest();//Calls create vest function, returns back object for AttachmentSlotItems

            AttachmentSlotItemSet Face = CreateMask();//Calls create mask function, returns back object for AttachmentSlotItems

            AttachmentSlotItemSet Eyewear = CreateEyewear();//Calls create mask function, returns back object for AttachmentSlotItems

            AttachmentSlotItemSet Gloves = CreateGloves();//Calls create gloves function, returns glove object for AttachmentSlotItems

            AttachmentSlotItemSet Feet = CreateFeet();//Calls create feet function, returns feet object for AttachmentSlotItems

            AttachmentSlotItemSet Armband = CreateArmband();//Calls create armband function, returns armband object for AttachmentSlotItems

            AttachmentSlotItemSet Headgear = CreateHeadgear();//Calls create headgear function, returns headgear object for AttachmentSlotItems

            AttachmentSlotItemSet Hands = CreateHands();//Calls create hands function, returns hands object for AttachmentSlotItems

            AttachmentSlotItemSet ShoulderL = CreateShoulderL();//Calls create ShoulderR function, returns SL object for AttachmentSlotItems

            AttachmentSlotItemSet ShoulderR = CreateShoulderR();//Calls create ShoulderR function, returns SR object for AttachmentSlotItems

            //Create AttachmentSlotItemSet List, only adds objects if user has selected something from that slot
            List<AttachmentSlotItemSet> attachmentSlotItemSetList = new List<AttachmentSlotItemSet>();
            if (cmbLSMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(ShoulderL);
            }
            if (cmbRSMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(ShoulderR);
            }
            if (cmbHandMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(Hands);
            }
            if (cmbHelmetMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(Headgear);
            }
            if (cmbArmbandMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(Armband);
            }
            if (cmbFaceMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(Feet);
            }
            if (cmbGlovesMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(Gloves);
            }
            if (cmbEyeWearMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(Eyewear);
            }
            if (cmbVestMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add (Vest);
            }
            if (cmbBackMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(Back);
            }
            if (cmbFaceMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(Face);
            }
            if (cmbPantsMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(Legs);
            }
            if (cmbShirtMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(Body);
            }
            if (cmbBeltMain.SelectedIndex != 0)
            {
                attachmentSlotItemSetList.Add(Hips);
            }

            //Calls create cargo function, returns the DiscreteUnsortedItemSet list into a local variable, *List is created in ftn!!!*
            List<DiscreteUnsortedItemSet> discreteUnsortedItemSetList = CreateCargo();

            //variables created for info to be sent in when root class is instantiated, based on user input from main form
            int spawnWeight = (int)nudSpawnChance.Value;
            string name = txtLoadoutName.Text;

            //Creates root class
            Root loadout = new Root(spawnWeight, name, attachmentSlotItemSetList, discreteUnsortedItemSetList);

            //Serialize Json into text for writing
            string loadoutString = JsonConvert.SerializeObject(loadout, Formatting.Indented); 

            //Create sfd so user can slect save path, then use streamwriter to write to file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Spawn JSON";
            saveFileDialog.DefaultExt = "json";
            saveFileDialog.Filter = "JSON files (*.json)|*.json";
            saveFileDialog.FileName = "myloadout.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter file = new StreamWriter(path))
                    {
                        file.Write(loadoutString);
                    }

                    MessageBox.Show("File saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for shoulderR
        //Description: Creates attachmentslotitemset for shoulderR based on user selection
        private AttachmentSlotItemSet CreateShoulderR()
        {
            //Create simplechildren list place items in that dont require batt
            List<string> attachmentSimpleChildList = new List<string>();
            if (cmbRS4.SelectedIndex != 0)
            {
                string item = cmbRS4.Text;
                attachmentSimpleChildList.Add(item);
            }
            if (cmbRS5.SelectedIndex != 0)
            {
                string item = cmbRS5.Text;
                attachmentSimpleChildList.Add(item);
            }
            if (cmbRS6.SelectedIndex != 0)
            {
                string item = cmbRS6.Text;
                attachmentSimpleChildList.Add(item);
            }
            if (cmbRS7.SelectedIndex != 0)
            {
                string item = cmbRS7.Text;
                attachmentSimpleChildList.Add(item);
            }
            //Create a complexitem object for each attachment that could require battery and add it to the list
            List<ComplexChildrenType> RSAttachmentComplexList = new List<ComplexChildrenType>();
            // Sight
            if (cmbRSSight.SelectedIndex != 0)
            {
                string item = cmbRSSight.Text;
                ComplexChildrenType sight = chkRSSight.Checked ? new ComplexChildrenType(item, bat9V) : new ComplexChildrenType(item);
                RSAttachmentComplexList.Add(sight);
            }
            // Light
            if (cmbRSLight.SelectedIndex != 0)
            {
                string item = cmbRSLight.Text;
                ComplexChildrenType light = chkRSLight.Checked ? new ComplexChildrenType(item, bat9V) : new ComplexChildrenType(item);
                RSAttachmentComplexList.Add(light);
            }
            // Magazine
            if (cmbRSMag.SelectedIndex != 0)
            {
                //selects string from parralel array so proper mag name is entered into object
                int arrayNum = cmbRSMag.SelectedIndex;
                string item = magCode[arrayNum].ToString();

                ComplexChildrenType mag = new ComplexChildrenType(item);
                RSAttachmentComplexList.Add(mag);
            }



            //Creates legs obj then places into list
            string shoulderRItemType = cmbRSMain.Text;
            int shoulderRHS = Convert.ToInt32(nudHSRightShoulder.Value);
            DiscreteItemSet shoulderR = new DiscreteItemSet(shoulderRItemType, shoulderRHS, RSAttachmentComplexList, attachmentSimpleChildList);
            List<DiscreteItemSet> shoulderRList = new List<DiscreteItemSet> { shoulderR };

            //Creates AttachmentSlotItemSet object for hips, enters list created and string for slotName
            AttachmentSlotItemSet shoulderRAttachmentItem = new AttachmentSlotItemSet("shoulderR", shoulderRList);

            return shoulderRAttachmentItem;
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for shoulderL
        //Description: Creates attachmentslotitemset for shoulderL based on user selection
        private AttachmentSlotItemSet CreateShoulderL()
        {
            //Create simplechildren list place items in that dont require batt
            List<string> attachmentSimpleChildList = new List<string>();
            if (cmbLS4.SelectedIndex != 0)
            {
                string item = cmbLS4.Text;
                attachmentSimpleChildList.Add(item);
            }
            if (cmbLS5.SelectedIndex != 0)
            {
                string item = cmbLS5.Text;
                attachmentSimpleChildList.Add(item);
            }
            if (cmbLS6.SelectedIndex != 0)
            {
                string item = cmbLS6.Text;
                attachmentSimpleChildList.Add(item);
            }
            if (cmbLS7.SelectedIndex != 0)
            {
                string item = cmbLS7.Text;
                attachmentSimpleChildList.Add(item);
            }
            //Create a complexitem object for each attachment that could require battery and add it to the list
            List<ComplexChildrenType> LSAttachmentComplexList = new List<ComplexChildrenType>();
            // Sight
            if (cmbLSSight.SelectedIndex != 0)
            {
                string item = cmbLSSight.Text;
                ComplexChildrenType sight = chkBatLSSight.Checked ? new ComplexChildrenType(item, bat9V) : new ComplexChildrenType(item);
                LSAttachmentComplexList.Add(sight);
            }
            // Light
            if (cmbLSLight.SelectedIndex != 0)
            {
                string item = cmbLSLight.Text;
                ComplexChildrenType light = chkBatLSLight.Checked ? new ComplexChildrenType(item, bat9V) : new ComplexChildrenType(item);
                LSAttachmentComplexList.Add(light);
            }
            // Magazine
            if (cmbLS3.SelectedIndex != 0)
            {
                //selects string from parralel array so proper mag name is entered into object
                int arrayNum = cmbLS3.SelectedIndex;
                string item = magCode[arrayNum].ToString();

                ComplexChildrenType mag = new ComplexChildrenType(item);
                LSAttachmentComplexList.Add(mag);
            }



            //Creates legs obj then places into list
            string shoulderLItemType = cmbLSMain.Text;
            int shoulderLHS = Convert.ToInt32(nudHSLeftShoulder.Value);
            DiscreteItemSet shoulderL = new DiscreteItemSet(shoulderLItemType, shoulderLHS, LSAttachmentComplexList, attachmentSimpleChildList);
            List<DiscreteItemSet> shoulderLList = new List<DiscreteItemSet> { shoulderL };

            //Creates AttachmentSlotItemSet object for hips, enters list created and string for slotName
            AttachmentSlotItemSet shoulderLAttachmentItem = new AttachmentSlotItemSet("shoulderL", shoulderLList);

            return shoulderLAttachmentItem;
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for hands
        //Description: Creates attachmentslotitemset for hands based on user selection
        private AttachmentSlotItemSet CreateHands()
        {
            //Create simplechildren list place items in that dont require batt
            List<string> attachmentSimpleChildList = new List<string>();
            if (cmbHand4.SelectedIndex != 0)
            {
                string item = cmbHand4.Text;
                attachmentSimpleChildList.Add(item);
            }
            if (cmbHand5.SelectedIndex != 0)
            {
                string item = cmbHand5.Text;
                attachmentSimpleChildList.Add(item);
            }
            if (cmbHand6.SelectedIndex != 0)
            {
                string item = cmbHand6.Text;
                attachmentSimpleChildList.Add(item);
            }
            if (cmbHand7.SelectedIndex != 0) 
            {
                string item = cmbHand7.Text;
                attachmentSimpleChildList.Add(item);
            }
           //Create a complexitem object for each attachment that could require battery and add it to the list
           List<ComplexChildrenType> handAttachmentComplexList = new List<ComplexChildrenType>();
            // Light
            if (cmbHandLight.SelectedIndex != 0)
            {
                string item = cmbHandLight.Text;
                ComplexChildrenType light = chkHandsLight.Checked ? new ComplexChildrenType(item, bat9V) : new ComplexChildrenType(item);
                handAttachmentComplexList.Add(light);
            }
            // Sight
            if (cmbHandSight.SelectedIndex != 0)
            {
                string item = cmbHandSight.Text;
                ComplexChildrenType sight = chkHandsSight.Checked ? new ComplexChildrenType(item, bat9V) : new ComplexChildrenType(item);
                handAttachmentComplexList.Add(sight);
            }
            // Magazine
            if (cmbHandMag.SelectedIndex != 0)
            {
                //selects string from parralel array so proper mag name is entered into object
                int arrayNum = cmbHandMag.SelectedIndex;
                string item = magCode[arrayNum].ToString();

                ComplexChildrenType mag = new ComplexChildrenType(item);
                handAttachmentComplexList.Add(mag);
            }



            //Creates legs obj then places into list
            string handsItemType = cmbHandMain.Text;
            int handsHS = Convert.ToInt32(nudHSHands.Value);
            DiscreteItemSet hands = new DiscreteItemSet(handsItemType, handsHS, handAttachmentComplexList, attachmentSimpleChildList);
            List<DiscreteItemSet> handsList = new List<DiscreteItemSet> { hands };

            //Creates AttachmentSlotItemSet object for hips, enters list created and string for slotName
            AttachmentSlotItemSet handsAttachmentItem = new AttachmentSlotItemSet("Hands", handsList);

            return handsAttachmentItem;
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for headgear
        //Description: Creates attachmentslotitemset for headgear based on user selection
        private AttachmentSlotItemSet CreateHeadgear()
        {
            List<ComplexChildrenType> headgearComplexList = new List<ComplexChildrenType>();
            if (chkHelmetNods.Checked)
            {
                ComplexChildrenType nods = new ComplexChildrenType("NVGoggles", bat9V);
                headgearComplexList.Add(nods);
            }
            if (chkHelmetLight.Checked)
            {
                ComplexChildrenType tacLight = new ComplexChildrenType("UniversalLight", bat9V);
                headgearComplexList.Add(tacLight);
            }


            //Creates legs obj then places into list
            string headgearItemType = cmbHelmetMain.Text;
            DiscreteItemSet headgear = new DiscreteItemSet(headgearItemType, headgearComplexList);
            List<DiscreteItemSet> headgearList = new List<DiscreteItemSet> { headgear };

            //Creates AttachmentSlotItemSet object for hips, enters list created and string for slotName
            AttachmentSlotItemSet headgearAttachmentItem = new AttachmentSlotItemSet("Headgear", headgearList);

            return headgearAttachmentItem;
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for armband
        //Description: Creates attachmentslotitemset for armband based on user selection
        private AttachmentSlotItemSet CreateArmband()
        {
            //Creates legs obj then places into list
            string armbandItemType = cmbArmbandMain.Text;
            DiscreteItemSet armband = new DiscreteItemSet(armbandItemType);
            List<DiscreteItemSet> armbandList = new List<DiscreteItemSet> { armband };

            //Creates AttachmentSlotItemSet object for hips, enters list created and string for slotName
            AttachmentSlotItemSet armbandAttachmentItem = new AttachmentSlotItemSet("Armband", armbandList);

            return armbandAttachmentItem;
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for feet
        //Description: Creates attachmentslotitemset for feet based on user selection
        private AttachmentSlotItemSet CreateFeet()
        {
            List<ComplexChildrenType> feetComplexChildList = new List<ComplexChildrenType>();   
            if (cmbFeetKnife.SelectedIndex != 0)
            {
                string knifeItemType = cmbFeetKnife.Text;
                int knifeHS = Convert.ToInt32(nudHSFeetKnife.Value);
                ComplexChildrenType knife = new ComplexChildrenType(knifeItemType, knifeHS);
                feetComplexChildList.Add(knife);
            }

            //Creates legs obj then places into list
            string feetItemType = cmbFeetMain.Text;
            DiscreteItemSet feet = new DiscreteItemSet(feetItemType, feetComplexChildList);
            List<DiscreteItemSet> feetList = new List<DiscreteItemSet> { feet };

            //Creates AttachmentSlotItemSet object for hips, enters list created and string for slotName
            AttachmentSlotItemSet feetAttachmentItem = new AttachmentSlotItemSet("Feet", feetList);

            return feetAttachmentItem;
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for gloves
        //Description: Creates attachmentslotitemset for gloves based on user selection
        private AttachmentSlotItemSet CreateGloves()
        {
            //Creates legs obj then places into list
            string glovesItemType = cmbGlovesMain.Text;
            DiscreteItemSet gloves = new DiscreteItemSet(glovesItemType);
            List<DiscreteItemSet> glovesList = new List<DiscreteItemSet> { gloves };

            //Creates AttachmentSlotItemSet object for hips, enters list created and string for slotName
            AttachmentSlotItemSet glovesAttachmentItem = new AttachmentSlotItemSet("Gloves", glovesList);

            return glovesAttachmentItem;
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for eyewear
        //Description: Creates attachmentslotitemset for eyewear based on user selection
        private AttachmentSlotItemSet CreateEyewear()
        {
            List<ComplexChildrenType> eyewearComplexList = new List<ComplexChildrenType>();
            string eyewearItemType = cmbEyeWearMain.Text;
            if (chkEyeWearNods.Checked )
            {
                ComplexChildrenType nods = new ComplexChildrenType("NVGoggles", bat9V);
                eyewearComplexList.Add(nods);
            }

            //Creates eyewear obj then places into list
            DiscreteItemSet eyewear = new DiscreteItemSet(eyewearItemType, eyewearComplexList);
            List<DiscreteItemSet> eyewearList = new List<DiscreteItemSet> { eyewear };

            //Creates AttachmentSlotItemSet object for hips, enters list created and string for slotName
            AttachmentSlotItemSet eyewearAttachmentItem = new AttachmentSlotItemSet("Eyewear", eyewearList);

            return eyewearAttachmentItem;
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for mask
        //Description: Creates attachmentslotitemset for mask based on user selection
        private AttachmentSlotItemSet CreateMask()
        {
            //Creates legs obj then places into list
            string maskItemType = cmbFaceMain.Text;
            DiscreteItemSet mask = new DiscreteItemSet(maskItemType);
            List<DiscreteItemSet> maskList = new List<DiscreteItemSet> { mask };

            //Creates AttachmentSlotItemSet object for hips, enters list created and string for slotName
            AttachmentSlotItemSet maskAttachmentItem = new AttachmentSlotItemSet("Mask", maskList);

            return maskAttachmentItem;
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for Vest
        //Description: Creates attachmentslotitemset for Vest based on user selection
        private AttachmentSlotItemSet CreateVest()
        {
            string vestItemType = cmbVestMain.Text;
            List<String> attachmentList = new List<String>();

            if (cmbVest2.SelectedIndex != 0) 
            {
                attachmentList.Add(cmbVest2.Text);
            }

            if (cmbVest3.SelectedIndex != 0)
            {
                attachmentList.Add(cmbVest3.Text);
            }

            //Creates discreteitemset list from user selection, then an attachmentslotitemset
            DiscreteItemSet vest = new DiscreteItemSet(vestItemType, attachmentList);
            List<DiscreteItemSet> vestList = new List<DiscreteItemSet> { vest };
            AttachmentSlotItemSet vestAttachmentItem = new AttachmentSlotItemSet("Vest", vestList);

            return vestAttachmentItem;
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for Back
        //Description: Creates attachmentslotitemset for Back based on user selection
        private AttachmentSlotItemSet CreateBack()
        {
            //variables from user input and complexchild list made so if else if chain can add depending on user selection
            string backItemType = cmbBackMain.Text;
            List<ComplexChildrenType> backAttachments = new List<ComplexChildrenType>(); 
            //Adds different item to list depending on slection
            if (radRadio.Checked)
            {
                ComplexChildrenType radio = new ComplexChildrenType("PersonalRadio", bat9V);
                backAttachments.Add(radio);
            }
            else if (radGPS.Checked) 
            {
                ComplexChildrenType gps = new ComplexChildrenType("GPSReceiver", bat9V);
                backAttachments.Add(gps);
            }
            else if (radGlowstick.Checked)
            {
                ComplexChildrenType glowstick = new ComplexChildrenType("Chemlight_Blue");
                backAttachments.Add(glowstick);
            }
            else //if nothing selected creates a discreteitem object with no complex list entered uses default in constructor
            {
                //Creates discreteitemset list from user selection, then an attachmentslotitemset
                DiscreteItemSet back = new DiscreteItemSet(backItemType);
                List<DiscreteItemSet> backList = new List<DiscreteItemSet> { back };
                AttachmentSlotItemSet backAttachmentItem = new AttachmentSlotItemSet("Back", backList);

                return backAttachmentItem;
            }

            //Creates discreteitemset list from user selection, then an attachmentslotitemset
            DiscreteItemSet back2 = new DiscreteItemSet(backItemType, backAttachments);
            List<DiscreteItemSet> backList2 = new List<DiscreteItemSet> { back2 };
            AttachmentSlotItemSet backAttachmentItem2 = new AttachmentSlotItemSet("Back", backList2);
            
            return backAttachmentItem2;
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for Legs
        //Description: Creates attachmentslotitemset for legs based on user selection
        private AttachmentSlotItemSet CreateLegs()
        {
            //Creates legs obj then places into list
            string legsItemType = cmbPantsMain.Text;
            DiscreteItemSet legs = new DiscreteItemSet(legsItemType);
            List<DiscreteItemSet> legsList = new List<DiscreteItemSet> { legs };

            //Creates AttachmentSlotItemSet object for hips, enters list created and string for slotName
            AttachmentSlotItemSet legsAttachmentItem = new AttachmentSlotItemSet("Legs", legsList);

            return legsAttachmentItem;
        }


        //Sent: Nil
        //Return: AttachmentSlotItemSet for Body
        //Description: Creates attachmentslotitemset for body based on user selection
        private AttachmentSlotItemSet CreateBody()
        {
            //Creates Body obj then places into list
            string bodyItemType = cmbShirtMain.Text;
            DiscreteItemSet body = new DiscreteItemSet(bodyItemType);
            List<DiscreteItemSet> bodyList = new List<DiscreteItemSet> { body };

            //Creates AttachmentSlotItemSet object for hips, enters list created and string for slotName
            AttachmentSlotItemSet bodyAttachmentItem = new AttachmentSlotItemSet("Body", bodyList);
        
            return bodyAttachmentItem;
        }


        //Sent: Nil
        //Return: DiscreteUnsortedItemSet <List>
        //Description: Creates discreteunsorteditemset object from userInventory lists sent from edit page, the creates discreteunsorteditemset list with that 
        // object and returns it.
        private static List<DiscreteUnsortedItemSet> CreateCargo()
        {
            //Inventory object created, based on selection in edit form
            DiscreteUnsortedItemSet cargoDiscreteUnsortedItemSet = new DiscreteUnsortedItemSet("Cargo1", userInventoryListComplexChildren, userInventoryListSimpleChildren);
            /* string inventory = JsonConvert.SerializeObject(cargoDiscreteUnsortedItemSet, Formatting.Indented);
            MessageBox.Show(inventory); */

            //DiscreteUnsortedItemSet List created and cargo object added
            List<DiscreteUnsortedItemSet> cargoDiscreteUnsortedItemSetList = new List<DiscreteUnsortedItemSet>
            {
                cargoDiscreteUnsortedItemSet
            };

            return cargoDiscreteUnsortedItemSetList;
        }


        //Sent: nil
        //Returned: AttachmentSlotItem for hips
        //Description: Creates attachmentslotitem set for HIPS
        private AttachmentSlotItemSet CreateHips()
        {
            //created pistolAttachmentSelection list
            List<ComplexChildrenType> pistolAttachmentSelection = new List<ComplexChildrenType>();
            if (chkBeltRDS.Checked)
            {
                ComplexChildrenType PistolRDS = new ComplexChildrenType("FNP45_MRDSOptic", bat9V);
                pistolAttachmentSelection.Add(PistolRDS);

            }
            if (chkBeltSup.Checked)
            {
                ComplexChildrenType PistolSup = new ComplexChildrenType("PistolSuppressor");
                pistolAttachmentSelection.Add(PistolSup);
            }
            if (chkBeltLight.Checked)
            {
                ComplexChildrenType PistolLight = new ComplexChildrenType("TLRLight", bat9V);
                pistolAttachmentSelection.Add(PistolLight);
            }
            if (chkBeltMag.Checked)
            {
                if (cmbBeltPistol.SelectedIndex == 1) //CZ75
                {
                    ComplexChildrenType PistolMag = new ComplexChildrenType("Mag_CZ75_15Rnd");
                    pistolAttachmentSelection.Add(PistolMag);
                }
                else if (cmbBeltPistol.SelectedIndex == 2) //1911
                {
                    ComplexChildrenType PistolMag = new ComplexChildrenType("Mag_1911_7Rnd");
                    pistolAttachmentSelection.Add(PistolMag);
                }
                else if (cmbBeltPistol.SelectedIndex == 3)//deagle
                {
                    ComplexChildrenType PistolMag = new ComplexChildrenType("Mag_Deagle_9rnd");
                    pistolAttachmentSelection.Add(PistolMag);
                }
                else if (cmbBeltPistol.SelectedIndex == 4)//gold deagle
                {
                    ComplexChildrenType PistolMag = new ComplexChildrenType("Mag_Deagle_9rnd");
                    pistolAttachmentSelection.Add(PistolMag);
                }
                else if (cmbBeltPistol.SelectedIndex == 5)//engraved 1911
                {
                    ComplexChildrenType PistolMag = new ComplexChildrenType("Mag_1911_7Rnd");
                    pistolAttachmentSelection.Add(PistolMag);
                }
                else if (cmbBeltPistol.SelectedIndex == 6)//fx45
                {
                    ComplexChildrenType PistolMag = new ComplexChildrenType("Mag_FNX45_15Rnd");
                    pistolAttachmentSelection.Add(PistolMag);
                }
                else if (cmbBeltPistol.SelectedIndex == 7)//glock
                {
                    ComplexChildrenType PistolMag = new ComplexChildrenType("Mag_Glock_15Rnd");
                    pistolAttachmentSelection.Add(PistolMag);
                }
                else if (cmbBeltPistol.SelectedIndex == 9)//u-70
                {
                    ComplexChildrenType PistolMag = new ComplexChildrenType("Mag_IJ70_8Rnd");
                    pistolAttachmentSelection.Add(PistolMag);
                }
                else if (cmbBeltPistol.SelectedIndex == 10)//P1
                {
                    ComplexChildrenType PistolMag = new ComplexChildrenType("Mag_P1_8Rnd");
                    pistolAttachmentSelection.Add(PistolMag);
                }
                else if (cmbBeltPistol.SelectedIndex == 11)//mk11
                {
                    ComplexChildrenType PistolMag = new ComplexChildrenType("Mag_MKII_10Rnd");
                    pistolAttachmentSelection.Add(PistolMag);
                }
            }


            //Creates pistolSelection List
            List<ComplexChildrenType> pistolSelection = new List<ComplexChildrenType>();
            if (cmbBeltPistol.SelectedIndex != 0)
            {
                string PistolSelection = cmbBeltPistol.Text;
                int pistolHS = Convert.ToInt32(nudHSBeltPistol.Value);
                ComplexChildrenType newPistol = new ComplexChildrenType(PistolSelection, pistolHS, pistolAttachmentSelection);
                pistolSelection.Add(newPistol);
            }
            //string testPistol = JsonConvert.SerializeObject(pistolSelection, Formatting.Indented);
            //MessageBox.Show(testPistol);


            //Creates holster list
            List<ComplexChildrenType> holsterSelection = new List<ComplexChildrenType>();
            if (cmbBeltHolster.SelectedIndex != 0)
            {
                string holster = cmbBeltHolster.Text;
                ComplexChildrenType HolsterSlection = new ComplexChildrenType(holster, pistolSelection);
                holsterSelection.Add(HolsterSlection);

            }
            //string testHolster = JsonConvert.SerializeObject(holsterSelection, Formatting.Indented);
            //MessageBox.Show(testHolster);


            //creates knifeSelection object
            List<ComplexChildrenType> knifeSelection = new List<ComplexChildrenType>();
            if (cmbBeltKnife.SelectedIndex != 0)
            {
                //creates variables for knife itemname and HS from user, then instantiates obj and places in list
                string KnifeSelection = cmbBeltKnife.Text;
                int knifeHSSelection = Convert.ToInt32(nudHSBeltKnife.Value);
                ComplexChildrenType knifeSelectionObj = new ComplexChildrenType(KnifeSelection, knifeHSSelection);
                knifeSelection.Add(knifeSelectionObj);
            }
            //string testKnife = JsonConvert.SerializeObject(knife, Formatting.Indented);
            //MessageBox.Show(testKnife);


            //creates sheathSelection and ropeKnifeSelection lists
            List<ComplexChildrenType> sheathSelection = new List<ComplexChildrenType>();
            List<ComplexChildrenType> ropeKnifeSelection = new List<ComplexChildrenType>();
            //creates sheath list, or knife obj for rope belt
            if (cmbBeltKnife.SelectedIndex != 0 && cmbBeltKnife.SelectedIndex != 6)
            {
                string sheath = "LeatherKnifeSheath";
                ComplexChildrenType SheathSelection = new ComplexChildrenType(sheath, knifeSelection);
                sheathSelection.Add(SheathSelection);
            }
            else if (chkBeltRopeKnife.Checked)
            {
                string knifeItem = "CombatKnife";
                int knifeHS = Convert.ToInt32(nudHSBeltKnife.Value);
                ComplexChildrenType ropeKnife = new ComplexChildrenType(knifeItem, knifeHS);
                ropeKnifeSelection.Add(ropeKnife);

            }
            //string testSheath = JsonConvert.SerializeObject(sheathSelection, Formatting.Indented);
            //MessageBox.Show(testSheath);


            //Create canteen ComplexChild Object
            ComplexChildrenType canteen = new ComplexChildrenType("Canteen");
            //string testCanteen = JsonConvert.SerializeObject(canteen, Formatting.Indented);
            //MessageBox.Show(testCanteen);


            //Created beltList Complex Child List
            List<ComplexChildrenType> beltList = new List<ComplexChildrenType>();
            // Add elements from pistolSelection, sheathSelection, canteen and ropeKnifeSelection lists if created
            if (cmbBeltPistol.SelectedIndex != 0)
                beltList.AddRange(holsterSelection);
            if (cmbBeltKnife.SelectedIndex != 0)
                beltList.AddRange(sheathSelection);
            if (chkBeltRopeKnife.Checked)
                beltList.AddRange(ropeKnifeSelection);
            if (chkBeltCanteen.Checked) { beltList.Add(canteen); } //Adds Canteen if checked
            //string testBelt = JsonConvert.SerializeObject(beltList, Formatting.Indented);
            //string testRope = JsonConvert.SerializeObject(ropeKnifeSelection, Formatting.Indented);
            //MessageBox.Show(testRope);
            //MessageBox.Show(testBelt);



            //DiscreteItemSet List created for hips and belt object added if selected cmb is not 0,
            //only one object will ever be added but a list is required to be sent in for syntax requirements
            List<DiscreteItemSet> hipList = new List<DiscreteItemSet>();
            string belt = cmbBeltMain.Text; //Belt input from user to be sent in to constructor
            if (cmbBeltMain.SelectedIndex != 0)
            {
                DiscreteItemSet hips = new DiscreteItemSet(belt, beltList);

                // Add the DiscreteItemSet object to the list
                hipList.Add(hips);
            }
            //string testHips = hips != null ? JsonConvert.SerializeObject(hips, Formatting.Indented) : ""; //If hips is not null will serialize, if null will be empty string, ensures null is not entered 
            //string testHips = JsonConvert.SerializeObject(hips, Formatting.Indented);
            //MessageBox.Show(testHips);


            //Created AttachmentSlotItemSet object for Hips
            AttachmentSlotItemSet Hips = new AttachmentSlotItemSet("Hips", hipList);

            return Hips;

        }

        //Description: Creates default selections for East rad
        private void radEast_CheckedChanged(object sender, EventArgs e)
        {
            //Resets all
            ResetRads();

            if (radEast.Checked)
            {
                //LS 
                cmbLSMain.SelectedIndex = 7;
                nudHSLeftShoulder.Value = 0;
                cmbLSSight.SelectedIndex = 7;
                cmbLSLight.SelectedIndex = 1;
                cmbLS3.SelectedIndex = 6;
                cmbLS4.SelectedIndex = 3;
                cmbLS5.SelectedIndex = 7;
                cmbLS6.SelectedIndex = 10;
                //RS
                cmbRSMain.SelectedIndex = 50;
                nudHSRightShoulder.Value = 1;
                cmbRSSight.SelectedIndex = 11;
                cmbRSMag.SelectedIndex = 35;
                cmbRS4.SelectedIndex = 10;
                //Hands
                cmbHandMain.SelectedIndex = 24;
                nudHSHands.Value = 2;
                //Vest
                cmbVestMain.SelectedIndex = 2;
                cmbVest2.SelectedIndex = 2;
                cmbVest3.SelectedIndex = 2;
                //Shirt
                cmbShirtMain.SelectedIndex = 36;
                //Hips
                cmbBeltMain.SelectedIndex = 5;
                cmbBeltKnife.SelectedIndex = 2;
                nudHSBeltKnife.Value = 3;
                cmbBeltHolster.SelectedIndex = 2;
                cmbBeltPistol.SelectedIndex = 9;
                nudHSBeltPistol.Value = 4;
                chkBeltMag.Checked = true;
                chkBeltSup.Checked = true;
                //Pants
                cmbPantsMain.SelectedIndex = 13;
                //Back
                cmbBackMain.SelectedIndex = 4;
                radRadio.Checked = true;
                //Face
                cmbFaceMain.SelectedIndex = 2;
                //Eyewear
                cmbEyeWearMain.SelectedIndex = 3;
                //Gloves
                cmbGlovesMain.SelectedIndex = 17;
                //Feet
                cmbFeetMain.SelectedIndex = 7;
                //Armband
                cmbArmbandMain.SelectedIndex = 17;
                //Helmet
                cmbHelmetMain.SelectedIndex = 29;
                //Loadout Name
                txtLoadoutName.Text = "EasternLoadout";
            }
        }

        //Description: Creates default selections for West rad
        private void radWest_CheckedChanged(object sender, EventArgs e)
        {
            ResetRads();


            if (radWest.Checked)
            {
                //LS M4
                cmbLSMain.SelectedIndex = 26;
                nudHSLeftShoulder.Value = 0;
                cmbLSSight.SelectedIndex = 9;
                cmbLSLight.SelectedIndex = 1;
                cmbLS3.SelectedIndex = 34;
                cmbLS4.SelectedIndex = 27;
                cmbLS5.SelectedIndex = 25;
                cmbLS6.SelectedIndex = 30;
                //RS M14
                cmbRSMain.SelectedIndex = 25;
                nudHSRightShoulder.Value = 1;
                cmbRSSight.SelectedIndex = 1;
                cmbRSMag.SelectedIndex = 24;
                //Hands
                cmbHandMain.SelectedIndex = 24;
                nudHSHands.Value = 2;
                //Vest
                cmbVestMain.SelectedIndex = 4;
                cmbVest2.SelectedIndex = 4;
                cmbVest3.SelectedIndex = 4;
                //Shirt
                cmbShirtMain.SelectedIndex = 95;
                //Hips
                cmbBeltMain.SelectedIndex = 5;
                cmbBeltKnife.SelectedIndex = 2;
                nudHSBeltKnife.Value = 3;
                cmbBeltHolster.SelectedIndex = 4;
                cmbBeltPistol.SelectedIndex = 4;
                nudHSBeltPistol.Value = 4;
                chkBeltRDS.Checked = true;
                chkBeltMag.Checked = true;
                chkBeltSup.Checked = true;
                //Pants
                cmbPantsMain.SelectedIndex = 62;
                //Back
                cmbBackMain.SelectedIndex = 5;
                radRadio.Checked = true;
                //Face
                cmbFaceMain.SelectedIndex = 9;
                //Eyes
                cmbEyeWearMain.SelectedIndex = 1;
                //Gloves
                cmbGlovesMain.SelectedIndex = 18;
                //Feet
                cmbFeetMain.SelectedIndex = 38;
                cmbFeetKnife.SelectedIndex = 3;
                //Armband
                cmbArmbandMain.SelectedIndex = 6;
                //Helmet
                cmbHelmetMain.SelectedIndex = 34;
                //Names loadout
                txtLoadoutName.Text = "WesternLoadout";
            }
        }

        //Description: Creates default selections for Black rad
        private void radBlack_CheckedChanged(object sender, EventArgs e)
        {
            ResetRads();

            if (radBlack.Checked)
            {
                //Vest
                cmbVestMain.SelectedIndex = 2;
                cmbVest2.SelectedIndex = 2;
                cmbVest3.SelectedIndex = 2;
                //Shirt
                cmbShirtMain.SelectedIndex = 36;
                //Hips
                cmbBeltMain.SelectedIndex = 5;
                cmbBeltKnife.SelectedIndex = 2;
                nudHSBeltKnife.Value = 3;
                cmbBeltHolster.SelectedIndex = 2;
                cmbBeltPistol.SelectedIndex = 1;
                nudHSBeltPistol.Value = 4;
                chkBeltMag.Checked = true;
                chkBeltSup.Checked = true;
                chkBeltRDS.Checked = true;
                chkBeltLight.Checked = true;
                //Pants
                cmbPantsMain.SelectedIndex = 13;
                //Back
                cmbBackMain.SelectedIndex = 4;
                radRadio.Checked = true;
                //Face
                cmbFaceMain.SelectedIndex = 6;
                //Gloves
                cmbGlovesMain.SelectedIndex = 17;
                //Feet
                cmbFeetMain.SelectedIndex = 7;
                //Armband
                cmbArmbandMain.SelectedIndex = 5;
                //Helmet
                cmbHelmetMain.SelectedIndex = 34;
                //Name
                txtLoadoutName.Text = "BlackOut";
            }
        }

        //Description: Creates default selections for Camo rad
        private void radCamo_CheckedChanged(object sender, EventArgs e)
        {
            ResetRads();

            if (radCamo.Checked ) 
            {
                //Vest
                cmbVestMain.SelectedIndex = 3;
                cmbVest2.SelectedIndex = 3;
                cmbVest3.SelectedIndex = 3;
                //Shirt
                cmbShirtMain.SelectedIndex = 82;
                //Hips
                cmbBeltMain.SelectedIndex = 5;
                cmbBeltKnife.SelectedIndex = 2;
                nudHSBeltKnife.Value = 3;
                cmbBeltHolster.SelectedIndex = 3;
                cmbBeltPistol.SelectedIndex = 6;
                nudHSBeltPistol.Value = 4;
                chkBeltMag.Checked = true;
                chkBeltSup.Checked = true;
                chkBeltRDS.Checked = true;
                chkBeltLight.Checked = true;
                //Pants
                cmbPantsMain.SelectedIndex = 55;
                //Back
                cmbBackMain.SelectedIndex = 6;
                radRadio.Checked = true;
                //Face
                cmbFaceMain.SelectedIndex = 13;
                //Gloves
                cmbGlovesMain.SelectedIndex = 18;
                //Feet
                cmbFeetMain.SelectedIndex = 7;
                //Armband
                cmbArmbandMain.SelectedIndex = 17;
                //Helmet
                cmbHelmetMain.SelectedIndex = 34;
                //Name
                txtLoadoutName.Text = "Camo";


            }
        }

        //Resets all cmbs, keeps the inventory lists made by user
        private void ResetRads()
        {
            foreach (System.Windows.Forms.ComboBox comboBox in Controls.OfType<System.Windows.Forms.ComboBox>())
            {
                if (comboBox.Items.Count > 0)
                    comboBox.SelectedIndex = 0;
            }
            nudSpawnChance.Value = 1;
        }

    }
}

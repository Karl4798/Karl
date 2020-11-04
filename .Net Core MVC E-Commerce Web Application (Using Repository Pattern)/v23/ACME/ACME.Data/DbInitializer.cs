using ACME.Data.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ACME.Data
{

    // DB seed class
    public class DbInitializer
    {

        // Seed method
        public static void Seed(AppDbContext context, UserManager<AccountUser> userManager)
        {

            // Add all categories to the database
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            // Add all products to the database
            if (!context.Products.Any())
            {

                // Add products to the database
                context.AddRange
                (
                    new Product
                    {
                        Name = "Tumble Dryer",
                        Price = 11999.00M,
                        ShortDescription = "Bosch - 9kg Condensor Tumble Dryer - Silver",
                        LongDescription = "Large LED-Display for remaining time and 24 h end time delay, program status indication, special functions. Sensitive Drying System: Big Stainless steel drum with textile care structure, soft design paddles. Anti-crease cycle 120 min at the end of the program. Touch control buttons: Low Heat, Signal, less ironing, end time delay, program length, start/pause, Fine-tuning of drying aim, 24 h end time delay\r\n" +
                                          "Features:\r\n" +
                                          "- Comfort and safety\r\n" +
                                          "- AutoDry technology\r\n" +
                                          "- Soft dial\r\n" +
                                          "- EasyClean filter\r\n" +
                                          "- AntiVibration Design: more stability and quietness\r\n" +
                                          "- Drum interior light: LED\r\n" +
                                          "- Childproof\r\n" +
                                          "- Buzzer to indicate the end of cycle\r\n" +
                                          "- Glass door with frame Silver-inox, black-grey\r\n" +
                                          "- Comfort lock\r\n" +
                                          "- Door hinge: right-hand\r\n" +
                                          "Programs\r\n" +
                                          "- Special programs: woolen finish, mix, time program warm, time program cold, allergy plus, sportswear, Down wear, shirts 15\r\n" +
                                          "Specifications:\r\n" +
                                          "- Capacity: 9kg\r\n" +
                                          "- Dryer type: Condenser\r\n" +
                                          "LED Display / Touch control\r\n" +
                                          "Yes\r\n" +
                                          "Anti-crease setting / Reverse action\r\n" +
                                          "Yes\r\n" +
                                          "Brand\r\n" +
                                          "Bosch\r\n" +
                                          "Assembled Dimensions\r\n" +
                                          "59.8 x 59 x 84.2 cm\r\n" +
                                          "Model\r\n" +
                                          "WTG86400ZA\r\n" +
                                          "Colours\r\n" +
                                          "Silver\r\n" +
                                          "Energy Rating\r\n" +
                                          "B\r\n" +
                                          "Sensor Drying\r\n" +
                                          "Yes\r\n" +
                                          "Packaged weight\r\n" +
                                          "42 kg\r\n" +
                                          "Materials\r\n" +
                                          "Stainless steel\r\n" +
                                          "Tumble Dryer Types\r\n" +
                                          "Condenser (no hose)\r\n" +
                                          "Unpacked Weight\r\n" +
                                          "42 kg\r\n" +
                                          "What's in the box\r\n" +
                                          "x 1 Tumble Dryer",
                        Category = Categories["Appliances"],
                        ImageUrl = "b662e360-151b-4306-83ce-35709ed7e1aa_55836683-1-full.jpg",
                        InStock = true,
                        IsPreferredProduct = true
                    },
                    new Product
                    {
                        Name = "Toaster",
                        Price = 999.00M,
                        ShortDescription = "Russell Hobbs - 950W Legacy Gen2 Toaster",
                        LongDescription = "Whatever your style, we have a range of coloured toasters to match not only your kettle but your whole kitchen. Our range of colours includes red and cream toasters which prove most popular\r\n" +
                                          "Features:\r\n" +
                                          "- Stylish stainless steel finish\r\n" +
                                          "- Cancel/reheat/defrost functions\r\n" +
                                          "- Indicator lights\r\n" +
                                          "- Automatic power cut off function\r\n" +
                                          "- Variable Browning control with 6 heat settings\r\n" +
                                          "- Bread centring function\r\n" +
                                          "- Easy to clean removable crumb tray\r\n" +
                                          "- Cord storage\r\n" +
                                          "- Non-slip feet\r\n" +
                                          "Specifications:\r\n" +
                                          "- Assembled Dimensions: 29 x 18 x 18cm\r\n" +
                                          "- Weight: 1.1kg\r\n" +
                                          "- Colour: Red, Cream\r\n" +
                                          "- Material: Stainless Steel\r\n" +
                                          "- Power: 950W\r\n" +
                                          "- Warranty: 24 Months\r\n" +
                                          "What's in the box\r\n" +
                                          "x 1 Toaster\r\n" +
                                          "x 1 Instruction manual",
                        Category = Categories["Appliances"],
                        ImageUrl = "84ffe43e-4e1d-49b1-a0e4-b28c8f00ba08_6002322014967-1-full.jpg",
                        InStock = true,
                        IsPreferredProduct = true
                    },
                    new Product
                    {
                        Name = "Laptop",
                        Price = 47999.00M,
                        ShortDescription = "ASUS Zenbook Pro Duo 15 i7 16Gb 512GB SSD RTX2060 15.6 Notebook - Blue",
                        LongDescription = "Core i7-9750H | 16GB | 512GB SSD | RTX2060 6GB | 15.6\"\r\n" +
                                          "Specifications:\r\n" +
                                          "- Intel Core i7-9750H Processor 2.6 GHz (12M Cache, up to 4.5 GHz)\r\n" +
                                          "\r\n" +
                                          "- 512GB PCIEG3x2 NVME M.2 SSD\r\n" +
                                          "- NVIDIA GeForce RTX 2060 GDDR6 6GB\r\n" +
                                          "- Windows 10 (64bit)\r\n" +
                                          "- 15.6” UHD 3840X2160\r\n" +
                                          "Processor:\r\n" +
                                          "- Intel Core i7-9750H Processor 2.6 GHz (12M Cache, up to 4.5 GHz)\r\n" +
                                          "- Chipset - Mobile Intel HM370 Express Chipsets\r\n" +
                                          "Operating System:\r\n" +
                                          "- Windows 10 (64bit)\r\n" +
                                          "Office:\r\n" +
                                          "- Includes 1-month Trial for New Microsoft Office 365 Customers\r\n" +
                                          "Display:\r\n" +
                                          "- 15.6”\r\n" +
                                          "- Narrow border\r\n" +
                                          "- 400nits\r\n" +
                                          "- UHD 3840X2160 16:9\r\n" +
                                          "- Glare\r\n" +
                                          "- DCI-P3: 95%\r\n" +
                                          "- Touch\r\n" +
                                          "- Wide View\r\n" +
                                          "Memory:\r\n" +
                                          "- Slot N/A\r\n" +
                                          "\r\n" +
                                          "Storage :\r\n" +
                                          "- 512GB PCIEG3x2 NVME M.2 SSD\r\n" +
                                          "External video display modes:\r\n" +
                                          "- HDMI 1.4\r\n" +
                                          "Graphics:\r\n" +
                                          "- NVIDIA GeForce RTX 2060\r\n" +
                                          "- IGPU -Intel UHD Graphics 630\r\n" +
                                          "- Video memory GDDR6 6GB\r\n" +
                                          "Video Camera:\r\n" +
                                          "- HD IR Camera\r\n" +
                                          "Communications:\r\n" +
                                          "- Wi-Fi 6(Gig+) (802.11ax)\r\n" +
                                          "- Bluetooth 5.0 (Dual band) 2*2\r\n" +
                                          "- LAN - N/A\r\n" +
                                          "USB Port:\r\n" +
                                          "- 2x USB3.1 Type A (Gen2)\r\n" +
                                          "- 1x USB3.1-Type C (Gen2) with Thunderbolt\r\n" +
                                          "Interface:\r\n" +
                                          "- 1x USB3.1-Type C(Gen2) with Thunderbolt\r\n" +
                                          "Audio:\r\n" +
                                          "- Built-in speaker\r\n" +
                                          "- Built-in microphone\r\n" +
                                          "- Built-in array microphone harmon / kardon\r\n" +
                                          "Weight (Kg):\r\n" +
                                          "-2.89 KG (with 8 cell battery)\r\n" +
                                          "Dimension (cm) :\r\n" +
                                          "- 35.6(W) x 22.4(D) x 2.30 ~ 2.40 (H) cm\r\n" +
                                          "AC Adapter:\r\n" +
                                          "- 230W AC Adapter\r\n" +
                                          "- Output: 19.5V DC, 11.8A, 230W\r\n" +
                                          "- Input: 100~240V AC, 50/60Hz universal\r\n" +
                                          "Battery:\r\n" +
                                          "- 1WHrs, 4S2P, 8-cell Li-ion\r\n" +
                                          "- Replaceable Battery No\r\n" +
                                          "Keyboard:\r\n" +
                                          "- Type - Illuminated Chiclet Keyboard\r\n" +
                                          "Security:\r\n" +
                                          "- TPM (Firmware TPM)\r\n" +
                                          "What's in the box\r\n" +
                                          "Notebook\r\n" +
                                          "AC Adapter\r\n" +
                                          "Manuel\r\n" +
                                          "Stylus\r\n" +
                                          "Palmrest",
                        Category = Categories["Electronics and Computers"],
                        ImageUrl = "20492bb5-5a7e-45f0-86ae-7e2e1b9a8004_4718017397773-1-full.jpg",
                        InStock = true,
                        IsPreferredProduct = true
                    },
                    new Product
                    {
                        Name = "Notepad",
                        Price = 109.00M,
                        ShortDescription = "Notes, Parrot Notebook. Notebook, Lined Pages, Note Pad, Journal",
                        LongDescription = "110 Pages Lined PaperMatte FinishGreat Theme",
                        Category = Categories["Office and Stationery"],
                        ImageUrl = "3b438b2f-1729-4508-92fc-25c364f47a4d_9781542770811-full.jpg",
                        InStock = false,
                        IsPreferredProduct = true
                    },
                    new Product
                    {
                        Name = "Tent",
                        Price = 4929.00M,
                        ShortDescription = "Oztrail Bungalow 9 Tent",
                        LongDescription = "Design:\r\n" +
                                          "A large 3 room tent that combines the light weight and easy setup of a dome tent with the dimensions and form of a cabin tent. The flexible layout means the 3 rooms can be used as bedrooms, living or screen rooms. Easy to set up design with walls that are open and close, Large front, side and rear awnings open out for extra protection & cover.\r\n" +
                                          "Features and Benefits:\r\n" +
                                          "- Fly: Silver Coated UVTex 2000 Sun Tough Fly fabric - the UVtex treatment not only protects the fly from harsh UV rays, it also doubles as a 100 Percent waterproof barrier. Factory heat taped seams keep the tent waterproof by preventing seam leakage. Posi-Brace securely fastens your fly to the tent with these Velcro attachment points.\r\n" +
                                          "- Inner Tent: Polyester inner tent with No-See-Um mesh windows for ventilation but no biting insects.\r\n" +
                                          "- Floor: Heavy Duty PE Floor - Incorporating a bucket style floor with elevated seams keeping the moisture out but more importantly, you dry.\r\n" +
                                          "- Door: Easy Step D Doors - Oversize D-shaped doors for easy access to the interior with lower sills to minimise tripping.\r\n" +
                                          "- Pole System: Duraplus Fibreglass poles with stainless steel joiners for maximum durability. Portico Poles - Steel poles that create near vertical walls, high ceilings and increase the strength of the tent.\r\n" +
                                          "- Mesh Windows: No-See-Um Mesh - Ultra-fine mesh panels for total insect protection, no matter how small they are, while still allowing plenty of ventilation.\r\n" +
                                          "- Environmental Control: Large mesh walls create a fully ventilated environment. Large windows in the outer tent allow you to control your climate. DryGuard Plus protects windows from wind driven rain with storm flaps\r\n" +
                                          "- Zips: number 5 Coil zips for windows #8 Coil zips for door\r\n" +
                                          "- Climate Rating: Ideal for cold to tropical conditions.\r\n" +
                                          "- Pegs & Guy Ropes: Sturdy pegs included. Pre-attached guy ropes.\r\n" +
                                          "- 12V Ready: 1 centrally located light attachment loop & 1 lantern hook. Power cord access zip. Velcro Power Cord holders.\r\n" +
                                          "- Storage Solutions: 2 easy to locate side wall organiser pockets.\r\n" +
                                          "Specifications:\r\n" +
                                          "- Dimensions: Tent floor area: 220 cm x 540 cm Tent head height: 200 cm\r\n" +
                                          "- Three rooms: 180 x 220 cm each\r\n" +
                                          "- Weight: 16 kg\r\n" +
                                          "- Carry Bag: 150D carry bag provided\r\n" +
                                          "- Height: 200cm\r\n" +
                                          "- Carry Bag Size: 71x 33x 33cm\r\n" +
                                          "- Sleeps: 9 Adults\r\n" +
                                          "What's in the box\r\n" +
                                          "X1 Tent in Carry bag",
                        Category = Categories["Camping and Luggage"],
                        ImageUrl = "a5976819-be5e-477c-9532-f12487fbffe0_9320531075423-1-full.jpg",
                        InStock = true
                    },
                    new Product
                    {
                        Name = "Book",
                        Price = 229.00M,
                        ShortDescription = "Richard Branson (eBook)",
                        LongDescription = "Categories\t\r\n" +
                                          "Books / Books / Biography & Autobiography / Biography - Professionals & Academics\r\n" +
                                          "Warranty\t\r\n" +
                                          "Limited (6 months)\r\n" +
                                          "Published Date\t\r\n" +
                                          "2016-03-01\r\n" +
                                          "ISBN\t\r\n" +
                                          "9781530619375\r\n" +
                                          "Abridged\t\r\n" +
                                          "No\r\n" +
                                          "Year\t\r\n" +
                                          "2016\r\n" +
                                          "Barcode\t\r\n" +
                                          "9781530619375\r\n" +
                                          "Binding\t\r\n" +
                                          "20\r\n" +
                                          "Illustrated\t\r\n" +
                                          "No\r\n" +
                                          "Authors\t\r\n" +
                                          "J D Rockefeller\r\n" +
                                          "Date of Publication\t\r\n" +
                                          "2016-03-18\r\n" +
                                          "Publisher\t\r\n" +
                                          "Createspace Independent Publishing Platform\r\n" +
                                          "Author\t\r\n" +
                                          "J. D. Rockefeller\r\n" +
                                          "Country\t\r\n" +
                                          " United States\r\n" +
                                          "Number of Pages\t\r\n" +
                                          "26\r\n" +
                                          "Languages\t\r\n" +
                                          "English\r\n" +
                                          "Width (mm)\t\r\n" +
                                          "216\r\n" +
                                          "Title\t\r\n" +
                                          "Richard Branson's Lesson\r\n" +
                                          "Height (mm)\t\r\n" +
                                          "1",
                        Category = Categories["Books and Magazines"],
                        ImageUrl = "637179bc-fb8d-4eda-a768-0d66cca59eec_58933278-1-full.jpg",
                        InStock = true
                    },
                    new Product
                    {
                        Name = "Washing Machine",
                        Price = 4499.00M,
                        ShortDescription = "Bosch - 13kg Top Loader Washing Machine Serie 4 - Metallic",
                        LongDescription = "Power Wave: innovative impeller and dynamic water flow for good results. Hot or cold water inlet. Easy Start: start by one button\r\n" +
                                          "Features:\r\n" +
                                          "- 24 Hour delay start\r\n" +
                                          "- Buttons: On/off, Start delay, Temperature, start/pause with reload function, Rinse plus +1 +2 +3, Washing time, spin time\r\n" +
                                          "- Water height program\r\n" +
                                          "- Temperature keys\r\n" +
                                          "- Drain pump\r\n" +
                                          "- Lint filter: filters lint effectively and is easy to clean\r\n" +
                                          "- Power-off memory: automatically restarts the process\r\n" +
                                          "- Dual stabilizer rings: vibrations are minimized significantly\r\n" +
                                          "- Soft closing glass lid\r\n" +
                                          "- Door lock: child-proof locked cover\r\n" +
                                          "- Mobility handles and adjustable foot\r\n" +
                                          "- Graduator: level for easier adjustment\r\n" +
                                          "- Special programs: Automatic, Tub Clean, Pre-Soak program, Quick Mix, air dry, Memory 1, Normal, Soft, Strong\r\n" +
                                          "- Speed Perfect: save up to 20% time without compromise\r\n" +
                                          "- Capacity: 13kg\r\n" +
                                          "What's in the box\r\n" +
                                          "x 1 Washing Machine",
                        Category = Categories["Appliances"],
                        ImageUrl = "003e7ee3-a383-4b24-ba94-0e8f69f79862_55228467_1-full.jpg",
                        InStock = true
                    },
                    new Product
                    {
                        Name = "Television",
                        Price = 7499.00M,
                        ShortDescription = "Hisense 50 inch UHD Smart TV with HDR and Digital Tuner",
                        LongDescription = "Product Model Number 50B7100UW:\r\n" +
                                          "-Enjoy 4K resolution.\r\n" +
                                          "-HDR - See all the detail in dark and bright scenes.\r\n" +
                                          "-Easy to use Smart Hub, stream Netflix, Youtube, DSTV Now and Showmax\r\n" +
                                          "Image Display Resolution (Horiz x Vert) 3840 x 2160 \r\n" +
                                          "- Image refresh frequency 50\r\n" +
                                          "- Smooth motion rate 50\r\n" +
                                          "- Native contrast ratio  4000 : 1\r\n" +
                                          "- Viewing Angle (Horiz / Vert)  178/178\r\n" +
                                          "Connectivity RF- Radio frequency input 1\r\n" +
                                          "- AV input  1\r\n" +
                                          "- USB interface type 2.0 (Qty / List ….) 2 / USB 1, USB 2\r\n" +
                                          "- Optical digital audio output (SPDIF)  1\r\n" +
                                          "- Earphone jack 1\r\n" +
                                          "HDMI ports HDMI inputs  3\r\n" +
                                          "- HDMI type 4K@60Hz with HDCP version 2.2 HDMI 1, HDMI 2, HDMI 3\r\n" +
                                          "- HDMI 2.0 compliant input HDMI 1, HDMI 2, HDMI 3\r\n" +
                                          "- ARC -Audio Return Channel  HDMI 1\r\n" +
                                          "- CEC- Consumer Electronics Control via HDMI Yes\r\n" +
                                          "Smart TV Ethernet port (RJ45 connector)  1\r\n" +
                                          "- Wi-Fi  protocols IEEE 802.11 {b, g, n, ac, ad, ..} b, g, n\r\n" +
                                          "- Wi-Fi bands 2.4\r\n" +
                                          "- DLNA compliance  Yes \r\n" +
                                          "- Anyview (Screen mirroring) Yes\r\n" +
                                          "- UHD (4k) streaming Yes\r\n" +
                                          "- Freeview Plus - HbbTV 2.0 Yes\r\n" +
                                          "Digital TV reception Television system (DVB-T / DVB-T2) Yes / Yes\r\n" +
                                          "- Video decoder (MPEG2 / MPEG 4) Yes / Yes\r\n" +
                                          "- AC3 Surround sound decoder  Yes\r\n" +
                                          "- AS 4599.1 compliance Yes\r\n" +
                                          "- AS 4933.1 compliance Yes\r\n" +
                                          "- LCN- Logical channel number and DTV Service name support Yes\r\n" +
                                          "- Teletext  / Teletext signal interruption (TAB compliant) / 16 : 9 TLTX Yes / Yes / Yes \r\n" +
                                          "- Subtitles Yes\r\n" +
                                          "- RF Signal strength indicator Yes\r\n" +
                                          "- RF Signal quality indicator Yes\r\n" +
                                          "- RF Bit error rate indicator Yes\r\n" +
                                          "- EPG- Electronic programming guide, 7 days for all services  Yes\r\n" +
                                          "- Audio description (vision impairment aid)  Yes\r\n" +
                                          "- Parental rating lock Yes\r\n" +
                                          "Analogue TV reception Colour-Sound systems in VHF band PAL B\r\n" +
                                          "- Colour-Sound systems in UHF band PAL B\r\n" +
                                          "- Stereo sound decoder {A2, Nicam, ….} A2 / NICAM\r\n" +
                                          "- Teletext  / Teletext signal interruption (TAB compliant) / 16 : 9  TLTX Yes / Yes / Yes\r\n" +
                                          "- Subtitles Yes\r\n" +
                                          "Image processing Backlight control Yes\r\n" +
                                          "- Dynamic backlight control Yes\r\n" +
                                          "- Zoom function settings ( 4:3 / 16:9 / Auto /  Zoom 1 / Zoom 2) Yes / Yes / Yes / Yes / Yes\r\n" +
                                          "- HDR - High Dynamic Range for luminance (DMP / Netflix / HDMI) Yes / Yes / Yes\r\n" +
                                          "- HDR system (HDR10) Yes\r\n" +
                                          "- HLG (Hybrid Log-Gamma) for HDR  Yes\r\n" +
                                          "- HEVC (H.265) decoder Yes\r\n" +
                                          "Sound Audio power output per channel 10\r\n" +
                                          "- Automatic volume level (AVL) Yes\r\n" +
                                          "- Audio equalizer Yes\r\n" +
                                          "- Dolby Digital Yes\r\n" +
                                          "- Audio enhancement -Type {SRS, BBE, SAP, DBX-TV….} DTS Studio Sound\r\n" +
                                          "- Lip-sync  adjustment Yes\r\n" +
                                          "Features On/off timer Yes\r\n" +
                                          "- Power off if no signal Yes\r\n" +
                                          "- Sleep timer Yes\r\n" +
                                          "- Program lock Yes\r\n" +
                                          "- Software version OSD indication Yes\r\n" +
                                          "- Legal requirements: Disclaimer / Acceptance of Terms Yes / Yes\r\n" +
                                          "- Favourite channels list Yes\r\n" +
                                          "- OTA- Over the air software updates Yes\r\n" +
                                          "- Screen mirroring {Miracast, Anyview Cast, ...} Anyview Cast\r\n" +
                                          "- Smartphone remote control application {TV remote, ...} Yes\r\n" +
                                          "USB media player Personal Video Recorder Yes\r\n" +
                                          "- Time Shift Yes\r\n" +
                                          "- DTV Recording (EPG scheduling / start from Standby ) Yes / Yes\r\n" +
                                          "- MPEG4 (H.264) / H.265 decoder Yes / Yes \r\n" +
                                          "- DMP- Digital media player content (Music / Video / Photos ) Yes / Yes / Yes\r\n" +
                                          "- DMP Auto-play  Yes\r\n" +
                                          "- DMP for UHD content via USB Yes\r\n" +
                                          "- DMP File allocation table (FAT / FAT32  / NTFS) Yes / Yes  / Yes\r\n" +
                                          "- PVR  File allocation table (FAT / FAT32 / NTFS) Yes / Yes / Yes\r\n" +
                                          "Hardware Colour (Front bezel, rear, stand) Black / Black /  Black\r\n" +
                                          "- Supply  range [Voltage / Frequency ]  100 ~ 240V / 50, 60Hz\r\n" +
                                          "- Standby consumption  < 0.5W\r\n" +
                                          "Installation Stand area (Width / Depth) 935/210\r\n" +
                                          "- Wall mount dimensions (Horiz x  Vert) 200 x 200\r\n" +
                                          "- Wall mount, screw thread M6\r\n" +
                                          "- VESA compliance Yes\r\n" +
                                          "- Power cord length 155\r\n" +
                                          "Accessories Remote controller (Technology / Part number ) IR / EN2BS27H\r\n" +
                                          "- Battery (size / quantity)  AAA / 2\r\n" +
                                          "- User manual (Print) / Quick setup guide (Print) 1 / 1\r\n" +
                                          "\r\n" +
                                          "\r\n" +
                                          "\r\n" +
                                          "- Net weight (with stand / without stand) 9.1 / 9\r\n" +
                                          "- Gross weight 13\r\n" +
                                          "What's in the box\r\n" +
                                          "1 x TV\r\n" +
                                          "1 x Stand\r\n" +
                                          "1 x Instruction Manual\r\n" +
                                          "1 x remote\r\n" +
                                          "1 x power cable",
                        Category = Categories["Electronics and Computers"],
                        ImageUrl = "40fef9bb-9c50-436d-81fb-f5ae6b233b7f_6942147451977-1-full.jpg",
                        InStock = true
                    },
                    new Product
                    {
                        Name = "One Direction Poster Book",
                        Price = 99.00M,
                        ShortDescription = "Get closer to the dreamy 1D poster boys with all the pull-outs you could want, plus an awesome giant poster. ",
                        LongDescription = "Spot the gorgeous guys in every direction! Why settle for a back row seat when you can get a close-up view of the talented boy band heroes? As well as profiles, fun facts and incredible true stories of life on the road as one of the world’s hottest musical properties, this book is stuffed with glossy poster pages to adorn your walls. \r\n" +
                                          "You’ll find pull-out mini posters throughout the book, showing the boys in all sorts of fabulous poses, plus an incredible giant poster to take pride of place. Now all you have to do is work out where to hang each one!",
                        Category = Categories["Books and Magazines"],
                        ImageUrl = "4bd05b90-e7bf-4c70-82b5-07cd513e9d78_9780857263810 -1D-full.jpg",
                        InStock = false
                    }
                );
            }

            context.SaveChangesAsync().Wait();

            // Seed admin user in the database
            SeedUsers(userManager);

        }

        // Method used to seed an admin account in the database
        private static void SeedUsers(UserManager<AccountUser> userManager)
        {

            // Creates the account
            AccountUser user = new AccountUser
            {

                // Sets user information
                UserName = "admin@admin.com",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                AddressLine1 = "1 Admin Place",
                City = "Durban",
                FirstName = "Administrator",
                LastName = "Administrator",
                DateOfBirth = "1990-06-10",
                Province = "KZN",
                Postcode = 4001
            };

            // Creates the user
            IdentityResult result = userManager.CreateAsync(user, "P@ssword123!").Result;

            // If the user was created successfully, add the user to the "Admin" role
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, "Admin").Wait();
            }

        }

        internal static void Seed(object app)
        {
            throw new NotImplementedException();
        }

        // Dictionaries of categories that are added to the database when the seed method is run
        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { Name = "Appliances" },
                        new Category { Name = "Electronics and Computers" },
                        new Category { Name = "Office and Stationery" },
                        new Category { Name = "Camping and Luggage" },
                        new Category { Name = "Books and Magazines" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.Name, genre);
                    }
                }

                return categories;
            }

        }
    }
}

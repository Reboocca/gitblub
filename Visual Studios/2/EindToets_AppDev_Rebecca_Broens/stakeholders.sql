/*
MySQL Data Transfer
Source Host: localhost
Source Database: stakeholders
Target Host: localhost
Target Database: stakeholders
Date: 18-10-2011 11:33:20
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for customer
-- ----------------------------
CREATE TABLE `customer` (
  `No` int(11) NOT NULL DEFAULT '0',
  `Name` varchar(255) DEFAULT NULL,
  `Addre` varchar(255) DEFAULT NULL,
  `City` varchar(255) DEFAULT NULL,
  `State` varchar(255) DEFAULT NULL,
  `Country` varchar(255) DEFAULT NULL,
  `Balance` double DEFAULT NULL,
  `Max` double DEFAULT NULL,
  PRIMARY KEY (`No`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for employee
-- ----------------------------
CREATE TABLE `employee` (
  `No` int(11) NOT NULL,
  `Name` varchar(20) DEFAULT NULL,
  `PhoneExt` varchar(4) DEFAULT NULL,
  `Salary` double DEFAULT NULL,
  `Addr` varchar(30) DEFAULT NULL,
  `City` varchar(20) DEFAULT NULL,
  `State` varchar(20) DEFAULT NULL,
  `Country` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`No`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for parts
-- ----------------------------
CREATE TABLE `parts` (
  `No` int(11) NOT NULL,
  `VendorNo` int(11) DEFAULT NULL,
  `Description` varchar(30) DEFAULT NULL,
  `OnHand` double DEFAULT NULL,
  `OnOrder` double DEFAULT NULL,
  `Cost` double DEFAULT NULL,
  PRIMARY KEY (`No`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for stockholder
-- ----------------------------
CREATE TABLE `stockholder` (
  `No` int(11) NOT NULL,
  `Name` varchar(20) DEFAULT NULL,
  `Phone` varchar(10) DEFAULT NULL,
  `Shares` double DEFAULT NULL,
  `Addr` varchar(30) DEFAULT NULL,
  `City` varchar(20) DEFAULT NULL,
  `State` varchar(20) DEFAULT NULL,
  `Country` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`No`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Table structure for vendor
-- ----------------------------
CREATE TABLE `vendor` (
  `No` int(11) NOT NULL,
  `Name` varchar(30) DEFAULT '',
  `Addr` varchar(30) DEFAULT NULL,
  `City` varchar(20) DEFAULT NULL,
  `State` varchar(20) DEFAULT NULL,
  `Country` varchar(20) DEFAULT NULL,
  `Phone` varchar(20) DEFAULT NULL,
  `Balance` double DEFAULT NULL,
  PRIMARY KEY (`No`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- ----------------------------
-- Records 
-- ----------------------------
INSERT INTO `customer` VALUES ('1221', 'Kauai Dive Shoppe', '4-976 Sugarloaf Hwy', 'Kapaa Kauai', 'HI', 'US', '0', '1000');
INSERT INTO `customer` VALUES ('1231', 'Uniscox', 'PO Box Z-547', 'Freeport', '', 'Bahamas', '0', '1000');
INSERT INTO `customer` VALUES ('1351', 'Sight Diver', '1 Neptune Lane', 'Kato Paphos', '', 'Cyprus', '0', '1000');
INSERT INTO `customer` VALUES ('1354', 'Cayman Divers World Unlimited', 'PO Box 541', 'Grand Cayman', '', 'British West Indies', '450', '1000');
INSERT INTO `customer` VALUES ('1356', 'Tom Sawyer Diving Centre', '632-1 Third Frydenhoj', 'Christiansted', 'St. Croix', 'US Virgin Islands', '0', '1000');
INSERT INTO `customer` VALUES ('1380', 'Blue Jack Aqua Center', '23-738 Paddington Lane', 'Waipahu', 'HI', 'US', '0', '1000');
INSERT INTO `customer` VALUES ('1384', 'VIP Divers Club2', '32 Main St.', 'Christiansted', 'St. Croix', 'US Virgin Islands', '0', '1000');
INSERT INTO `customer` VALUES ('1510', 'Ocean Paradise', 'PO Box 8745', 'Kailua-Kona', 'HI', 'US', '0', '10000');
INSERT INTO `customer` VALUES ('1513', 'Fantastique Aquatica', 'Z32 999 #12A-77 A.A.', 'Bogota', '', 'Columbia', '0', '1000');
INSERT INTO `customer` VALUES ('1551', 'Marmot Divers Club', '872 Queen St.', 'Kitchener', 'Ontario', 'Canada', '0', '1000');
INSERT INTO `customer` VALUES ('1560', 'The Depth Charge', '15243 Underwater Fwy.', 'Marathon', 'FL', 'US', '-167.21', '1000');
INSERT INTO `customer` VALUES ('1563', 'Blue Sports', '203 12th Ave. Box 746', 'Giribaldi', 'OR', 'US', '2019.81', '5000');
INSERT INTO `customer` VALUES ('1624', 'Makai SCUBA Club', 'PO Box 8534', 'Kailua-Kona', 'HI', 'US', '0', '1000');
INSERT INTO `customer` VALUES ('1645', 'Action Club', 'PO Box 5451-F', 'Sarasota', 'FL', 'US', '0', '1000');
INSERT INTO `customer` VALUES ('1651', 'Jamaica SCUBA Centre', 'PO Box 68', 'Negril', 'Jamaica', 'West Indies', '0', '1000');
INSERT INTO `customer` VALUES ('1680', 'Island Finders', '6133 1/3 Stone Avenue', 'St Simons Isle', 'GA', 'US', '0', '1000');
INSERT INTO `customer` VALUES ('1984', 'Adventure Undersea', 'PO Box 744', 'Belize City', '', 'Belize', '0', '1000');
INSERT INTO `customer` VALUES ('2118', 'Blue Sports Club', '63365 Nez Perce Street', 'Largo', 'FL', 'US', '890.89', '5000');
INSERT INTO `customer` VALUES ('2135', 'Frank\'s Divers Supply', '1455 North 44th St.', 'Eugene', 'OR', 'US', '0', '1000');
INSERT INTO `customer` VALUES ('2156', 'Davy Jones\' Locker', '246 South 16th Place', 'Vancouver', 'BC', 'Canada', '0', '1000');
INSERT INTO `customer` VALUES ('2163', 'SCUBA Heaven', 'PO Box Q-8874', 'Nassau', '', 'Bahamas', '0', '1000');
INSERT INTO `customer` VALUES ('2165', 'Shangri-La Sports Center', 'PO Box D-5495', 'Freeport', '', 'Bahamas', '0', '1000');
INSERT INTO `customer` VALUES ('2315', 'Divers of Corfu, Inc.', 'Marmoset Place 54', 'Ayios Matthaios', 'Corfu', 'Greece', '0', '1000');
INSERT INTO `customer` VALUES ('2354', 'Kirk Enterprises', '42 Aqua Lane', 'Houston', 'TX', 'US', '0', '1000');
INSERT INTO `customer` VALUES ('2975', 'George Bean en Co.', '#73 King Salmon Way', 'Lugoff', 'NC', 'US', '0', '1000');
INSERT INTO `customer` VALUES ('2984', 'Professional Divers, Ltd.', '4734 Melinda St.', 'Hoover', 'AL', 'US', '209.65', '10000');
INSERT INTO `customer` VALUES ('3041', 'Divers of Blue-green', '634 Complex Ave.', 'Pelham', 'AL', 'US', '0', '1000');
INSERT INTO `customer` VALUES ('3042', 'Gold Coast Supply', '223-B Houston Place', 'Mobile', 'AL', 'US', '0', '1000');
INSERT INTO `customer` VALUES ('3051', 'San Pablo Dive Center', '1701-D N Broadway', 'Santa Maria', 'CA', 'US', '0', '1000');
INSERT INTO `customer` VALUES ('3052', 'Underwater Sports Co.', '351-A Sarasota St.', 'San Jose', 'CA', 'US', '0', '1000');
INSERT INTO `customer` VALUES ('3053', 'American SCUBA Supply', '1739 Atlantic Avenue', 'Lomita', 'CA', 'US', null, null);
INSERT INTO `customer` VALUES ('3054', 'Catamaran Dive Club', 'Box 264 Pleasure Point', 'Catalina Island', 'CA', 'US', null, null);
INSERT INTO `customer` VALUES ('3055', 'Diver\'s Grotto', '24601 Universal Lane', 'Downey', 'CA', 'US', null, null);
INSERT INTO `customer` VALUES ('3151', 'Fisherman\'s Eye', 'PO Box 7542', 'Grand Cayman', '', 'British West Indies', null, null);
INSERT INTO `customer` VALUES ('3158', 'Action Diver Supply', 'Blue Spar Box #3', 'St. Thomas', '', 'US Virgin Islands', null, null);
INSERT INTO `customer` VALUES ('3615', 'Marina SCUBA Center', 'PO Box 82438 Zulu 7831', 'Caracas', '', 'Venezuela', null, null);
INSERT INTO `customer` VALUES ('3984', 'Blue Glass Happiness', '6345 W. Shore Lane', 'Santa Monica', 'CA', 'US', null, null);
INSERT INTO `customer` VALUES ('4312', 'Divers of Venice', '220 Elm Street', 'Venice', 'FL', 'US', null, null);
INSERT INTO `customer` VALUES ('4531', 'On-Target SCUBA', '7-73763 Nanakawa Road', 'Winnipeg', 'Manitoba', 'Canada', null, null);
INSERT INTO `customer` VALUES ('4652', 'Jamaica Sun, Inc.', 'PO Box 643', 'Runaway Bay', 'Jamaica', 'West Indies', null, null);
INSERT INTO `customer` VALUES ('4684', 'Underwater Fantasy', 'PO Box 842', 'Ocho Rios', 'Jamaica', 'West Indies', null, null);
INSERT INTO `customer` VALUES ('5132', 'Princess Island SCUBA', 'PO Box 32 Waiyevo', 'Taveuni', '', 'Fiji', null, null);
INSERT INTO `customer` VALUES ('5151', 'Central Underwater Supplies', 'PO Box 737', 'Johannesburg', '', 'Republic So. Africa', null, null);
INSERT INTO `customer` VALUES ('5163', 'Safari Under the Sea', 'PO Box 7456', 'Grand Cayman', '', 'British West Indies', null, null);
INSERT INTO `customer` VALUES ('5165', 'Larry\'s Diving School', '3562 NW Bruce Street', 'Milwaukie', 'OR', 'US', null, null);
INSERT INTO `customer` VALUES ('5384', 'Tora Tora Tora', 'PO Box H-4573', 'Nassau', '', 'Bahamas', null, null);
INSERT INTO `customer` VALUES ('5412', 'Vashon Ventures', '743 Keyhole Court', 'Honolulu', 'HI', 'US', null, null);
INSERT INTO `customer` VALUES ('5432', 'Divers-for-Hire', 'G.O. P Box 91', 'Suva', '', 'Fiji', null, null);
INSERT INTO `customer` VALUES ('5515', 'Ocean Adventures', 'PO Box 466 Kihei', 'Maui', 'HI', 'US', null, null);
INSERT INTO `customer` VALUES ('6215', 'Underwater SCUBA Company', 'PO Box Sn 91', 'Somerset', '', 'Bermuda', null, null);
INSERT INTO `customer` VALUES ('6312', 'Aquatic Drama', '921 Everglades Way', 'Tampa', 'FL', 'US', null, null);
INSERT INTO `customer` VALUES ('6516', 'The Diving Company', 'PO Box 8535', 'St. Thomas', '', 'US Virgin Islands', null, null);
INSERT INTO `customer` VALUES ('6582', 'Norwest\'er SCUBA Limited', 'PO Box 6834', 'Paget', '', 'Bermuda', null, null);
INSERT INTO `customer` VALUES ('6812', 'Waterspout SCUBA Center', '7865 NE Barber Ct.', 'Portland', 'OR', 'US', null, null);
INSERT INTO `customer` VALUES ('9841', 'Neptune\'s Trident Supply', 'PO Box 129', 'Negril', 'Jamaica', 'West Indies', null, null);
INSERT INTO `employee` VALUES ('2', 'Nelson', '250', '40000', null, null, null, null);
INSERT INTO `employee` VALUES ('4', 'Young', '233', '55500', null, null, null, null);
INSERT INTO `employee` VALUES ('5', 'Lambert', '22', '25000', null, null, null, null);
INSERT INTO `employee` VALUES ('8', 'Johnson', '410', '25050', null, null, null, null);
INSERT INTO `employee` VALUES ('9', 'Forest', '229', '25050', null, null, null, null);
INSERT INTO `employee` VALUES ('11', 'Weston', '34', '33292', null, null, null, null);
INSERT INTO `employee` VALUES ('12', 'Lee', '256', '45332', null, null, null, null);
INSERT INTO `employee` VALUES ('14', 'Hall', '227', '44482', null, null, null, null);
INSERT INTO `employee` VALUES ('15', 'Young', '231', '24400', null, null, null, null);
INSERT INTO `employee` VALUES ('20', 'Papadopoulos', '887', '25050', null, null, null, null);
INSERT INTO `employee` VALUES ('24', 'Fisher', '888', '23040', null, null, null, null);
INSERT INTO `employee` VALUES ('28', 'Bennet', '5', '44482', null, null, null, null);
INSERT INTO `employee` VALUES ('29', 'De Souza', '288', '25500', null, null, null, null);
INSERT INTO `employee` VALUES ('34', 'Baldwin', '2', '23300', null, null, null, null);
INSERT INTO `employee` VALUES ('36', 'Reeves', '6', '33620', null, null, null, null);
INSERT INTO `employee` VALUES ('37', 'Stansbury', '7', '49224', null, null, null, null);
INSERT INTO `employee` VALUES ('44', 'Phong', '216', '40350', null, null, null, null);
INSERT INTO `employee` VALUES ('45', 'Ramanathan', '209', '32924', null, null, null, null);
INSERT INTO `employee` VALUES ('46', 'Steadman', '210', '19599', null, null, null, null);
INSERT INTO `employee` VALUES ('52', 'Nordstrom', '420', '14500', null, null, null, null);
INSERT INTO `employee` VALUES ('61', 'Leung', '3', '34500', null, null, null, null);
INSERT INTO `employee` VALUES ('65', 'O\'Brien', '877', '31275', null, null, null, null);
INSERT INTO `employee` VALUES ('71', 'Burbank', '289', '45332', null, null, null, null);
INSERT INTO `employee` VALUES ('72', 'Sutherland', '', '45699', null, null, null, null);
INSERT INTO `employee` VALUES ('83', 'Bishop', '290', '45000', null, null, null, null);
INSERT INTO `employee` VALUES ('85', 'MacDonald', '477', '45699', null, null, null, null);
INSERT INTO `employee` VALUES ('94', 'Williams', '892', '28900', null, null, null, null);
INSERT INTO `employee` VALUES ('105', 'Bender', '255', '36799', null, null, null, null);
INSERT INTO `employee` VALUES ('107', 'Cook', '894', '35500', null, null, null, null);
INSERT INTO `employee` VALUES ('109', 'Brown', '202', '27000', null, null, null, null);
INSERT INTO `employee` VALUES ('110', 'Ichida', '22', '25689', null, null, null, null);
INSERT INTO `employee` VALUES ('113', 'Page', '845', '48000', null, null, null, null);
INSERT INTO `employee` VALUES ('114', 'Parker', '247', '45000', null, null, null, null);
INSERT INTO `employee` VALUES ('118', 'Yamamoto', '23', '32500', null, null, null, null);
INSERT INTO `employee` VALUES ('121', 'Ferrari', '1', '40500', null, null, null, null);
INSERT INTO `employee` VALUES ('127', 'Yanowski', '492', '44000', null, null, null, null);
INSERT INTO `employee` VALUES ('134', 'Glon', '', '24855', null, null, null, null);
INSERT INTO `parts` VALUES ('900', '3820', 'Dive kayak', '24', '16', '1356.75');
INSERT INTO `parts` VALUES ('912', '3820', 'Underwater Diver Vehicle', '5', '3', '504');
INSERT INTO `parts` VALUES ('1313', '3511', 'Regulator System', '165', '216', '117.5');
INSERT INTO `parts` VALUES ('1314', '5641', 'Second Stage Regulator', '98', '88', '124.1');
INSERT INTO `parts` VALUES ('1316', '3511', 'Regulator System', '75', '70', '119.35');
INSERT INTO `parts` VALUES ('1320', '3511', 'Second Stage Regulator', '37', '35', '73.53');
INSERT INTO `parts` VALUES ('1328', '3511', 'Regulator System', '166', '100', '154.8');
INSERT INTO `parts` VALUES ('1330', '3511', 'Alternate Inflation Regulator', '47', '43', '85.8');
INSERT INTO `parts` VALUES ('1364', '3511', 'Second Stage Regulator', '128', '135', '99.9');
INSERT INTO `parts` VALUES ('1390', '3511', 'First Stage Regulator', '146', '140', '64.6');
INSERT INTO `parts` VALUES ('1946', '6588', 'Second Stage Regulator', '13', '10', '95.79');
INSERT INTO `parts` VALUES ('1986', '6588', 'Depth/Pressure Gauge Console', '25', '24', '73.32');
INSERT INTO `parts` VALUES ('2314', '3511', 'Electronic Console', '13', '12', '120.9');
INSERT INTO `parts` VALUES ('2341', '3511', 'Depth/Pressure Gauge', '226', '225', '48.3');
INSERT INTO `parts` VALUES ('2343', '3511', 'Personal Dive Sonar', '46', '45', '72.85');
INSERT INTO `parts` VALUES ('2350', '3511', 'Compass Console Mount', '211', '300', '10.15');
INSERT INTO `parts` VALUES ('2367', '3511', 'Compass (meter only)', '168', '183', '24.96');
INSERT INTO `parts` VALUES ('2383', '3511', 'Depth/Pressure Gauge', '128', '120', '76.22');
INSERT INTO `parts` VALUES ('2390', '3511', 'Electronic Console w/ options', '24', '23', '189');
INSERT INTO `parts` VALUES ('2612', '2014', 'Direct Sighting Compass', '15', '12', '12.582');
INSERT INTO `parts` VALUES ('2613', '2014', 'Dive Computer', '5', '2', '76.97');
INSERT INTO `parts` VALUES ('2619', '2014', 'Navigation Compass', '8', '20', '9.177');
INSERT INTO `parts` VALUES ('2630', '2014', 'Wrist Band Thermometer (F)', '6', '3', '7.92');
INSERT INTO `parts` VALUES ('2632', '2014', 'Depth/Pressure Gauge (Digital)', '12', '10', '53.64');
INSERT INTO `parts` VALUES ('2648', '2014', 'Depth/Pressure Gauge (Analog)', '16', '15', '39.27');
INSERT INTO `parts` VALUES ('2657', '2014', 'Wrist Band Thermometer (C)', '12', '10', '6.48');
INSERT INTO `parts` VALUES ('2954', '6588', 'Dive Computer', '45', '43', '253.5');
INSERT INTO `parts` VALUES ('3316', '3511', 'Stabilizing Vest', '56', '67', '146.2');
INSERT INTO `parts` VALUES ('3326', '3511', 'Front Clip Stabilizing Vest', '45', '56', '128.8');
INSERT INTO `parts` VALUES ('3340', '3511', 'Trim Fit Stabilizing Vest', '63', '61', '138.25');
INSERT INTO `parts` VALUES ('3386', '3511', 'Welded Seam Stabilizing Vest', '62', '60', '109.2');
INSERT INTO `parts` VALUES ('5313', '3511', 'Safety Knife', '16', '30', '13.12');
INSERT INTO `parts` VALUES ('5318', '5641', 'Medium Titanium Knife', '4', '3', '26.7665');
INSERT INTO `parts` VALUES ('5324', '3511', 'Chisel Point Knife', '14', '35', '14.35');
INSERT INTO `parts` VALUES ('5349', '3511', 'Flashlight', '28', '27', '29.25');
INSERT INTO `parts` VALUES ('5356', '3511', 'Medium Stainless Steel Knife', '30', '23', '34.3');
INSERT INTO `parts` VALUES ('5378', '3511', 'Divers Knife and Sheath', '24', '23', '27.3');
INSERT INTO `parts` VALUES ('5386', '3511', 'Large Stainless Steel Knife', '16', '15', '37.6');
INSERT INTO `parts` VALUES ('7612', '7382', 'Krypton Flashlight', '46', '76', '20.677');
INSERT INTO `parts` VALUES ('7619', '7382', 'Flashlight (Rechargeable)', '16', '36', '50.985');
INSERT INTO `parts` VALUES ('7654', '7382', 'Halogen Flashlight', '19', '18', '19.184');
INSERT INTO `parts` VALUES ('9312', '3511', '60.6 cu ft Tank', '8', '4', '57.28');
INSERT INTO `parts` VALUES ('9316', '3511', '95.1 cu ft Tank', '16', '14', '130');
INSERT INTO `parts` VALUES ('9318', '3511', '71.4 cu ft Tank', '102', '100', '58.5');
INSERT INTO `parts` VALUES ('9354', '3511', '75.8 cu ft Tank', '38', '31', '96.35');
INSERT INTO `parts` VALUES ('11221', '2674', 'Remotely Operated Video System', '13', '12', '710.7');
INSERT INTO `parts` VALUES ('11238', '7382', 'Marine Super VHS Video Package', '3', '1', '1124.1');
INSERT INTO `parts` VALUES ('11518', '4652', 'Towable Video Camera (B&W)', '12', '21', '859.57');
INSERT INTO `parts` VALUES ('11564', '4652', 'Towable Video Camera (Color)', '16', '39', '1484.55');
INSERT INTO `parts` VALUES ('11635', '7382', 'Camera and Case', '14', '12', '52.778');
INSERT INTO `parts` VALUES ('11652', '7382', 'Video Light', '5', '1', '147.5795');
INSERT INTO `parts` VALUES ('12301', '2674', 'Boat Towable Metal Detector', '13', '12', '203.66');
INSERT INTO `parts` VALUES ('12303', '2674', 'Boat Towable Metal Detector', '14', '11', '316.05');
INSERT INTO `parts` VALUES ('12306', '2674', 'Underwater Altimeter', '38', '34', '143.5');
INSERT INTO `parts` VALUES ('12310', '2674', 'Sonar System', '3', '120', '215.11');
INSERT INTO `parts` VALUES ('12316', '2674', 'Marine Magnetometer', '56', '55', '545.58');
INSERT INTO `parts` VALUES ('12317', '2674', 'Underwater Metal Detector', '29', '24', '440.51');
INSERT INTO `parts` VALUES ('12386', '2674', 'Underwater Metal Detector', '45', '41', '338.3');
INSERT INTO `parts` VALUES ('13545', '4682', 'Air Compressor', '5', '2', '986.85');
INSERT INTO `stockholder` VALUES ('134', 'Glon', '0312837019', '4855', '203 12th Ave. Box 746', 'Giribaldi', 'OR', 'US');
INSERT INTO `stockholder` VALUES ('136', 'Johnson', '2659424841', '305', '872 Queen St.', 'Kitchener', 'Ontario', 'Canada');
INSERT INTO `stockholder` VALUES ('138', 'Green', '2188274248', '90', '23-738 Paddington Lane', 'Waipahu', 'HI', 'US');
INSERT INTO `stockholder` VALUES ('141', 'Osborne', '0942828842', '2560', '246 South 16th Place', 'Vancouver', 'BC', 'Canada');
INSERT INTO `stockholder` VALUES ('144', 'Montgomery', '8203191349', '3569', '351-A Sarasota St.', 'San Jose', 'CA', 'US');
INSERT INTO `stockholder` VALUES ('145', 'Guckenheimer', '2210013343', '923', '24601 Universal Lane', 'Downey', 'CA', 'US');
INSERT INTO `vendor` VALUES ('2014', 'Cacor Corporation', 'TBS', 'Southfield', 'OH', 'US', '708-555-9555', '17.5');
INSERT INTO `vendor` VALUES ('2641', 'Underwater', 'TBS', 'Indianapolis', 'IN', 'US', '317-555-4523', '20.23');
INSERT INTO `vendor` VALUES ('2674', 'J.W.  Luscher Mfg.', 'TBS', 'Berkely', 'MA', 'US', '800-555-4744', '102.32');
INSERT INTO `vendor` VALUES ('3511', 'Scuba Professionals', 'TBS', 'Rancho Dominguez', 'CA', 'US', '213-555-7850', '0');
INSERT INTO `vendor` VALUES ('3819', 'Divers\'  Supply Shop', 'TBS', 'Macon', 'GA', 'US', '912-555-6790', '13');
INSERT INTO `vendor` VALUES ('3820', 'Techniques', 'TBS', 'Redwood City', 'CA', 'US', '415-555-1410', '90231.02');
INSERT INTO `vendor` VALUES ('4521', 'Perry Scuba', 'TBS', 'Hapeville', 'GA', 'US', '800-555-6220', '32.32');
INSERT INTO `vendor` VALUES ('4642', 'Beauchat, Inc.', 'TBS', 'Ft Lauderdale', 'FL', 'US', '305-555-7242', '123');
INSERT INTO `vendor` VALUES ('4651', 'Amor Aqua', 'TBS', 'New York', 'NY', 'US', '800-555-6880', '0');
INSERT INTO `vendor` VALUES ('4652', 'Aqua Research Corp.', 'TBS', 'Cornish', 'NH', 'US', '603-555-2254', '1023.98');
INSERT INTO `vendor` VALUES ('4655', 'B&K Undersea Photo', 'TBS', 'New York', 'NY', 'US', '800-555-5662', '1.23');
INSERT INTO `vendor` VALUES ('4681', 'Diving International Unlimited', 'TBS', 'San Diego', 'DA', 'US', '800-555-8439', '0');
INSERT INTO `vendor` VALUES ('4682', 'Nautical Compressors', 'TBS', 'Miami', 'FL', 'US', '305-555-5554', '-983.26');
INSERT INTO `vendor` VALUES ('5385', 'Glen Specialties, Inc.', 'TBS', 'Huntington Beach', 'CA', 'US', '714-555-5100', '4.26');
INSERT INTO `vendor` VALUES ('5641', 'Dive Time', 'TBS', 'Long Beach', 'CA', 'US', '213-555-3708', '0');
INSERT INTO `vendor` VALUES ('6415', 'Undersea Systems, Inc.', 'TBS', 'Huntington Beach', 'CA', 'US', '800-555-3483', '0');
INSERT INTO `vendor` VALUES ('6451', 'Felix Diving', 'TBS', 'Chicago', 'IL', 'US', '800-555-3549', '0');
INSERT INTO `vendor` VALUES ('6452', 'Central Valley Skin Divers', 'TBS', 'Jamaica', 'NY', 'US', '718-555-5772', '0');
INSERT INTO `vendor` VALUES ('6481', 'Parkway Dive Shop', 'TBS', 'South Amboy', 'NJ', 'US', '908-555-5300', '7863.3');
INSERT INTO `vendor` VALUES ('6482', 'Marine Camera & Dive', 'TBS', 'San Diego', 'CA', 'US', '619-555-0604', '0');
INSERT INTO `vendor` VALUES ('6588', 'Dive Canada', 'TBS', 'Vancouver', 'British Columbia', 'Canada', '604-555-2681', '0');
INSERT INTO `vendor` VALUES ('7382', 'Dive & Surf', 'TBS', 'Indianapolis', 'IN', 'US', '317-555-4523', '0');
INSERT INTO `vendor` VALUES ('7685', 'Fish Research Labs', 'TBS', 'Los Banos', 'CA', 'US', '209-555-3292', '0');
INSERT INTO `vendor` VALUES ('7932', 'Marine Camera & Dive', 'TBS', 'San Diego', 'CA', 'US', '619-555-0604', '0');

-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: akademine_sistema
-- ------------------------------------------------------
-- Server version	8.0.22

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `dalykas`
--

DROP TABLE IF EXISTS `dalykas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `dalykas` (
  `Da_ID` int NOT NULL AUTO_INCREMENT,
  `Da_Pav` varchar(225) NOT NULL,
  PRIMARY KEY (`Da_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dalykas`
--

LOCK TABLES `dalykas` WRITE;
/*!40000 ALTER TABLE `dalykas` DISABLE KEYS */;
INSERT INTO `dalykas` VALUES (1,'Lietuvių k.'),(2,'Matematika'),(3,'Objektinis programavimas'),(7,'3D Maketavimas'),(11,'Anglų k.');
/*!40000 ALTER TABLE `dalykas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `destytojo_dalykas`
--

DROP TABLE IF EXISTS `destytojo_dalykas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `destytojo_dalykas` (
  `De_ID` int NOT NULL,
  `Da_ID` int NOT NULL,
  KEY `Da_ID` (`Da_ID`),
  KEY `destytojo_dalykas_ibfk_1_idx` (`De_ID`),
  CONSTRAINT `destytojo_dalykas_ibfk_1` FOREIGN KEY (`De_ID`) REFERENCES `naudotojas` (`N_ID`),
  CONSTRAINT `destytojo_dalykas_ibfk_2` FOREIGN KEY (`Da_ID`) REFERENCES `dalykas` (`Da_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `destytojo_dalykas`
--

LOCK TABLES `destytojo_dalykas` WRITE;
/*!40000 ALTER TABLE `destytojo_dalykas` DISABLE KEYS */;
INSERT INTO `destytojo_dalykas` VALUES (4,2),(5,3),(18,1),(18,7);
/*!40000 ALTER TABLE `destytojo_dalykas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `grupe`
--

DROP TABLE IF EXISTS `grupe`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `grupe` (
  `G_ID` int NOT NULL AUTO_INCREMENT,
  `G_Pav` varchar(225) NOT NULL,
  PRIMARY KEY (`G_ID`),
  UNIQUE KEY `G_Pav_UNIQUE` (`G_Pav`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `grupe`
--

LOCK TABLES `grupe` WRITE;
/*!40000 ALTER TABLE `grupe` DISABLE KEYS */;
INSERT INTO `grupe` VALUES (8,'PI18B'),(1,'PI19A'),(4,'PI19D'),(12,'SI19A');
/*!40000 ALTER TABLE `grupe` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `naudotojas`
--

DROP TABLE IF EXISTS `naudotojas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `naudotojas` (
  `N_ID` int NOT NULL AUTO_INCREMENT,
  `Vardas` varchar(225) NOT NULL,
  `Pavarde` varchar(225) NOT NULL,
  `NL_ID` int NOT NULL,
  PRIMARY KEY (`N_ID`),
  KEY `NL_ID` (`NL_ID`),
  CONSTRAINT `naudotojas_ibfk_1` FOREIGN KEY (`NL_ID`) REFERENCES `naudotojo_lygis` (`NL_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `naudotojas`
--

LOCK TABLES `naudotojas` WRITE;
/*!40000 ALTER TABLE `naudotojas` DISABLE KEYS */;
INSERT INTO `naudotojas` VALUES (1,'Admin','Admin',3),(2,'Valerija','Murnevaitė',1),(3,'Jonas','Jonelis',1),(4,'Paulius','Skvernelis',2),(5,'Darius','Deteroko',2),(13,'Arnoldas','Bartiukas',2),(16,'Rokas','Smirnov',2),(17,'Ela','Tetereko',1),(18,'Arūnas','Stalas',2),(19,'Raimondas','Kasys',1),(20,'Saulius','Karalius',2),(22,'Rapolas','Kazys',1),(24,'Raimondas','Kazys',1);
/*!40000 ALTER TABLE `naudotojas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `naudotojo_lygis`
--

DROP TABLE IF EXISTS `naudotojo_lygis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `naudotojo_lygis` (
  `NL_ID` int NOT NULL AUTO_INCREMENT,
  `NL` varchar(225) NOT NULL,
  PRIMARY KEY (`NL_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `naudotojo_lygis`
--

LOCK TABLES `naudotojo_lygis` WRITE;
/*!40000 ALTER TABLE `naudotojo_lygis` DISABLE KEYS */;
INSERT INTO `naudotojo_lygis` VALUES (1,'Studentas'),(2,'Dėstytojas'),(3,'Administratorius');
/*!40000 ALTER TABLE `naudotojo_lygis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paskaitos`
--

DROP TABLE IF EXISTS `paskaitos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paskaitos` (
  `S_ID` int NOT NULL,
  `Da_ID` int NOT NULL,
  `Pazymis` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paskaitos`
--

LOCK TABLES `paskaitos` WRITE;
/*!40000 ALTER TABLE `paskaitos` DISABLE KEYS */;
INSERT INTO `paskaitos` VALUES (1,1,NULL),(2,2,10),(2,2,10),(2,7,7),(2,1,9);
/*!40000 ALTER TABLE `paskaitos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `studentas`
--

DROP TABLE IF EXISTS `studentas`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `studentas` (
  `S_ID` int NOT NULL AUTO_INCREMENT,
  `N_ID` int unsigned NOT NULL,
  `Grupe_ID` int unsigned DEFAULT NULL,
  PRIMARY KEY (`S_ID`),
  KEY `N_ID` (`N_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `studentas`
--

LOCK TABLES `studentas` WRITE;
/*!40000 ALTER TABLE `studentas` DISABLE KEYS */;
INSERT INTO `studentas` VALUES (1,2,1),(2,3,8),(9,17,4),(10,19,4),(11,22,NULL),(12,24,NULL);
/*!40000 ALTER TABLE `studentas` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'akademine_sistema'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-12-03 20:02:48

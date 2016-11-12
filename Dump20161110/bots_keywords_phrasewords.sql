use bots;
-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: bots
-- ------------------------------------------------------
-- Server version	5.7.14

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `keywords_phrasewords`
--

DROP TABLE IF EXISTS `keywords_phrasewords`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `keywords_phrasewords` (
  `keywordsid` int(11) NOT NULL,
  `phrasewordid` int(11) NOT NULL,
  PRIMARY KEY (`keywordsid`,`phrasewordid`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Linking table between keywords and phrasewords';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `keywords_phrasewords`
--

LOCK TABLES `keywords_phrasewords` WRITE;
/*!40000 ALTER TABLE `keywords_phrasewords` DISABLE KEYS */;
INSERT INTO `keywords_phrasewords` VALUES (1,1),(1,2),(1,3),(2,4),(4,5),(5,6),(6,7),(6,8),(7,9),(8,10),(8,11),(9,12),(10,12),(10,13),(11,12),(11,14),(12,11),(12,12),(13,12),(14,15),(14,16),(15,17),(16,18),(16,19),(17,23),(18,8),(18,20),(18,21),(18,22),(18,24),(18,25);
/*!40000 ALTER TABLE `keywords_phrasewords` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-11-10 16:54:14

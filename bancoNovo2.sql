-- MySQL dump 10.13  Distrib 5.7.12, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: iilic
-- ------------------------------------------------------
-- Server version	5.7.16-log

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
-- Table structure for table `administrador`
--

DROP TABLE IF EXISTS `administrador`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `administrador` (
  `num` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(100) NOT NULL,
  `cpf` varchar(14) NOT NULL,
  `dataNasc` date NOT NULL,
  `sexo` varchar(20) NOT NULL,
  `telefone` varchar(15) NOT NULL,
  `email` varchar(50) NOT NULL,
  PRIMARY KEY (`num`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `administrador`
--

LOCK TABLES `administrador` WRITE;
/*!40000 ALTER TABLE `administrador` DISABLE KEYS */;
INSERT INTO `administrador` VALUES (1,'testeadm','682.671.924-09','2016-12-01','masculino','(55) 55555-5555','jjjj@gmail.com'),(2,'teste','682.671.924-09','2016-12-02','masculino','(77) 77777-7777','jjjj@gmail.com');
/*!40000 ALTER TABLE `administrador` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `caracteristica`
--

DROP TABLE IF EXISTS `caracteristica`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `caracteristica` (
  `idCaracteristica` int(11) NOT NULL AUTO_INCREMENT,
  `nomeCaracteristica` varchar(50) NOT NULL,
  PRIMARY KEY (`idCaracteristica`)
) ENGINE=MyISAM AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `caracteristica`
--

LOCK TABLES `caracteristica` WRITE;
/*!40000 ALTER TABLE `caracteristica` DISABLE KEYS */;
INSERT INTO `caracteristica` VALUES (1,'Alegria'),(2,'Tristeza'),(3,'Coceira'),(4,'Rinite'),(5,'Dor');
/*!40000 ALTER TABLE `caracteristica` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `consulta`
--

DROP TABLE IF EXISTS `consulta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `consulta` (
  `idConsulta` int(11) NOT NULL AUTO_INCREMENT,
  `dia` date NOT NULL,
  `statusPagamento` int(11) NOT NULL,
  `codPaciente` int(11) NOT NULL,
  `numMed` int(11) NOT NULL,
  `hora` varchar(45) DEFAULT NULL,
  `statusConsulta` bit(1) NOT NULL DEFAULT b'0',
  PRIMARY KEY (`idConsulta`,`codPaciente`,`numMed`),
  KEY `fk_consulta_paciente_idx` (`codPaciente`),
  KEY `fk_consulta_terapeuta1_idx` (`numMed`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `consulta`
--

LOCK TABLES `consulta` WRITE;
/*!40000 ALTER TABLE `consulta` DISABLE KEYS */;
INSERT INTO `consulta` VALUES (1,'2016-12-04',1,2,2,'16:00','\0');
/*!40000 ALTER TABLE `consulta` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `doenca`
--

DROP TABLE IF EXISTS `doenca`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `doenca` (
  `idDoenca` int(11) NOT NULL AUTO_INCREMENT,
  `nomeDoenca` varchar(50) NOT NULL,
  PRIMARY KEY (`idDoenca`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `doenca`
--

LOCK TABLES `doenca` WRITE;
/*!40000 ALTER TABLE `doenca` DISABLE KEYS */;
/*!40000 ALTER TABLE `doenca` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `finanmes`
--

DROP TABLE IF EXISTS `finanmes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `finanmes` (
  `idFinanceiro` int(11) NOT NULL AUTO_INCREMENT,
  `valorTotalMes` float NOT NULL,
  PRIMARY KEY (`idFinanceiro`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `finanmes`
--

LOCK TABLES `finanmes` WRITE;
/*!40000 ALTER TABLE `finanmes` DISABLE KEYS */;
INSERT INTO `finanmes` VALUES (1,80),(2,20),(3,120),(4,80),(5,80),(6,80),(7,80);
/*!40000 ALTER TABLE `finanmes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `finansessao`
--

DROP TABLE IF EXISTS `finansessao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `finansessao` (
  `idfinanSessao` int(11) NOT NULL AUTO_INCREMENT,
  `valorSessao` float DEFAULT NULL,
  PRIMARY KEY (`idfinanSessao`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `finansessao`
--

LOCK TABLES `finansessao` WRITE;
/*!40000 ALTER TABLE `finansessao` DISABLE KEYS */;
INSERT INTO `finansessao` VALUES (1,100),(2,200),(3,100),(4,200),(5,400),(6,500),(7,100);
/*!40000 ALTER TABLE `finansessao` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logindb`
--

DROP TABLE IF EXISTS `logindb`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `logindb` (
  `idLogin` int(11) NOT NULL AUTO_INCREMENT,
  `login` varchar(100) NOT NULL,
  `senha` varchar(45) NOT NULL,
  `administrador_num` int(11) NOT NULL,
  PRIMARY KEY (`idLogin`,`administrador_num`),
  KEY `fk_logindb_administrador_idx` (`administrador_num`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logindb`
--

LOCK TABLES `logindb` WRITE;
/*!40000 ALTER TABLE `logindb` DISABLE KEYS */;
INSERT INTO `logindb` VALUES (1,'adm','adm',2);
/*!40000 ALTER TABLE `logindb` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `logintera`
--

DROP TABLE IF EXISTS `logintera`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `logintera` (
  `idLogintera` int(11) NOT NULL AUTO_INCREMENT,
  `login` varchar(100) NOT NULL,
  `senha` varchar(45) NOT NULL,
  `terapeuta_num` int(11) NOT NULL,
  PRIMARY KEY (`idLogintera`,`terapeuta_num`),
  KEY `fk_logintera_terapeuta_idx` (`terapeuta_num`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `logintera`
--

LOCK TABLES `logintera` WRITE;
/*!40000 ALTER TABLE `logintera` DISABLE KEYS */;
INSERT INTO `logintera` VALUES (1,'vitor','vitor',2);
/*!40000 ALTER TABLE `logintera` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paciente`
--

DROP TABLE IF EXISTS `paciente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `paciente` (
  `codPaciente` int(11) NOT NULL AUTO_INCREMENT,
  `nomePaciente` varchar(50) NOT NULL,
  `telefone` varchar(20) NOT NULL,
  `email` varchar(30) NOT NULL,
  `dataNascPac` date NOT NULL,
  `cpfPac` varchar(45) NOT NULL,
  PRIMARY KEY (`codPaciente`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paciente`
--

LOCK TABLES `paciente` WRITE;
/*!40000 ALTER TABLE `paciente` DISABLE KEYS */;
INSERT INTO `paciente` VALUES (1,'Juliana','(77) 77777-7777','jjjj@gmail.com','2016-12-01','682.671.924-09'),(2,'Fernanda','(99) 99999-9999','jjjj@gmail.com','2016-12-21','435.879.496-38');
/*!40000 ALTER TABLE `paciente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pagamento`
--

DROP TABLE IF EXISTS `pagamento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pagamento` (
  `idPagamento` int(11) NOT NULL AUTO_INCREMENT,
  `valor` float DEFAULT NULL,
  `tipoValor` int(11) DEFAULT NULL,
  `consulta_idConsulta` int(11) NOT NULL,
  `consulta_codPaciente` int(11) DEFAULT NULL,
  `consulta_numMed` int(11) DEFAULT NULL,
  PRIMARY KEY (`idPagamento`,`consulta_idConsulta`),
  KEY `fk_pagamento_consulta1_idx` (`consulta_idConsulta`,`consulta_codPaciente`,`consulta_numMed`),
  CONSTRAINT `fk_pagamento_consulta1` FOREIGN KEY (`consulta_idConsulta`, `consulta_codPaciente`, `consulta_numMed`) REFERENCES `consulta` (`idConsulta`, `codPaciente`, `numMed`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pagamento`
--

LOCK TABLES `pagamento` WRITE;
/*!40000 ALTER TABLE `pagamento` DISABLE KEYS */;
/*!40000 ALTER TABLE `pagamento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `relaciona`
--

DROP TABLE IF EXISTS `relaciona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `relaciona` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `idCaracteristica` int(11) NOT NULL,
  `paciente_num` int(11) NOT NULL,
  PRIMARY KEY (`id`,`idCaracteristica`,`paciente_num`),
  KEY `fk_relaciona_caracteristitca_idx` (`idCaracteristica`),
  KEY `fk_relaciona_paciente_idx` (`paciente_num`)
) ENGINE=MyISAM AUTO_INCREMENT=19 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `relaciona`
--

LOCK TABLES `relaciona` WRITE;
/*!40000 ALTER TABLE `relaciona` DISABLE KEYS */;
INSERT INTO `relaciona` VALUES (1,1,1),(2,4,1),(3,8,1),(10,41,1),(11,42,1),(12,41,2),(13,42,2),(14,1,2),(15,2,2),(16,3,2),(17,4,2),(18,5,2);
/*!40000 ALTER TABLE `relaciona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `terapeuta`
--

DROP TABLE IF EXISTS `terapeuta`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `terapeuta` (
  `numMed` int(11) NOT NULL AUTO_INCREMENT,
  `nomeMed` varchar(50) NOT NULL,
  `cpfMed` varchar(14) NOT NULL,
  `telefone` varchar(20) NOT NULL,
  `email` varchar(50) NOT NULL,
  `dataNascMed` date NOT NULL,
  `crm` varchar(11) NOT NULL,
  `sexo` varchar(20) NOT NULL,
  PRIMARY KEY (`numMed`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `terapeuta`
--

LOCK TABLES `terapeuta` WRITE;
/*!40000 ALTER TABLE `terapeuta` DISABLE KEYS */;
INSERT INTO `terapeuta` VALUES (1,'terapeuta','682.671.924-09','(55) 55555-5555','jjjj@gmail.com','2016-12-02','44','masculino'),(2,'vitor','818.400.176-27','(44) 44444-4444','jjjj@gmail.com','2016-12-01','1994','masculino');
/*!40000 ALTER TABLE `terapeuta` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-12-04 16:25:42

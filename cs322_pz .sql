-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 05, 2020 at 06:47 PM
-- Server version: 10.1.25-MariaDB
-- PHP Version: 5.6.31

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `cs322_pz`
--
CREATE DATABASE IF NOT EXISTS `cs322_pz` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `cs322_pz`;

-- --------------------------------------------------------

--
-- Table structure for table `bolesti`
--

CREATE TABLE IF NOT EXISTS `bolesti` (
  `BOLEST_ID` int(11) NOT NULL AUTO_INCREMENT,
  `NAZIV` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`BOLEST_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `bolesti`
--

INSERT INTO `bolesti` (`BOLEST_ID`, `NAZIV`) VALUES
(1, 'Dijabetes'),
(2, 'Hipertenzija'),
(3, 'Prehlada'),
(4, 'Upala grla'),
(5, 'Alergija');

-- --------------------------------------------------------

--
-- Table structure for table `boluje_od`
--

CREATE TABLE IF NOT EXISTS `boluje_od` (
  `BOLUJE_OD_ID` int(11) NOT NULL AUTO_INCREMENT,
  `PACIJENT_ID` int(11) DEFAULT NULL,
  `BOLEST_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`BOLUJE_OD_ID`),
  KEY `FK_RELATIONSHIP_6` (`PACIJENT_ID`),
  KEY `FK_RELATIONSHIP_7` (`BOLEST_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `boluje_od`
--

INSERT INTO `boluje_od` (`BOLUJE_OD_ID`, `PACIJENT_ID`, `BOLEST_ID`) VALUES
(1, 10, 2),
(3, 10, 1),
(4, 10, 2),
(5, 10, 2);

-- --------------------------------------------------------

--
-- Table structure for table `izabrani_lekar`
--

CREATE TABLE IF NOT EXISTS `izabrani_lekar` (
  `IZABRANI_LEKAR_ID` int(11) NOT NULL AUTO_INCREMENT,
  `RADNIK_ID` int(11) DEFAULT NULL,
  `PACIJENT_ID` int(11) DEFAULT NULL,
  PRIMARY KEY (`IZABRANI_LEKAR_ID`),
  KEY `FK_RELATIONSHIP_1` (`PACIJENT_ID`),
  KEY `FK_RELATIONSHIP_2` (`RADNIK_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `izabrani_lekar`
--

INSERT INTO `izabrani_lekar` (`IZABRANI_LEKAR_ID`, `RADNIK_ID`, `PACIJENT_ID`) VALUES
(1, 1, 8),
(2, 1, 9),
(3, 1, 10);

-- --------------------------------------------------------

--
-- Table structure for table `lekovi`
--

CREATE TABLE IF NOT EXISTS `lekovi` (
  `LEK_ID` int(11) NOT NULL AUTO_INCREMENT,
  `NAZIV` varchar(30) DEFAULT NULL,
  `DOZA` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`LEK_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `lekovi`
--

INSERT INTO `lekovi` (`LEK_ID`, `NAZIV`, `DOZA`) VALUES
(1, 'Aspirin', '30'),
(3, 'Cardiopirin', '10'),
(4, 'Andol', '20'),
(5, 'Vitamin C', '10'),
(6, 'Brufen', '30'),
(7, 'Presing', '10');

-- --------------------------------------------------------

--
-- Table structure for table `pacijenti`
--

CREATE TABLE IF NOT EXISTS `pacijenti` (
  `PACIJENT_ID` int(11) NOT NULL AUTO_INCREMENT,
  `IME` varchar(30) DEFAULT NULL,
  `PREZIME` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`PACIJENT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pacijenti`
--

INSERT INTO `pacijenti` (`PACIJENT_ID`, `IME`, `PREZIME`) VALUES
(2, 'Pacijent', 'Paja'),
(4, 'Pera', 'Detlic'),
(6, 'sdf', 'dsfds'),
(8, 'Dusko', 'Duskic'),
(9, 'a', 'a'),
(10, 'b', 'b');

-- --------------------------------------------------------

--
-- Table structure for table `pregledi`
--

CREATE TABLE IF NOT EXISTS `pregledi` (
  `PREGLED_ID` int(11) NOT NULL AUTO_INCREMENT,
  `RADNIK_ID` int(11) DEFAULT NULL,
  `PACIJENT_ID` int(11) DEFAULT NULL,
  `DATUM` date DEFAULT NULL,
  `VREME` time DEFAULT NULL,
  PRIMARY KEY (`PREGLED_ID`),
  KEY `FK_RELATIONSHIP_8` (`RADNIK_ID`),
  KEY `FK_RELATIONSHIP_9` (`PACIJENT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `pregledi`
--

INSERT INTO `pregledi` (`PREGLED_ID`, `RADNIK_ID`, `PACIJENT_ID`, `DATUM`, `VREME`) VALUES
(1, 1, 2, '0000-00-00', '17:03:00'),
(2, 1, 4, '0000-00-00', '17:07:38'),
(3, 1, 6, '0000-00-00', '17:09:20'),
(4, 1, 8, '0000-00-00', '17:13:13'),
(5, 1, 9, '2020-00-04', '17:16:38'),
(6, 1, 10, '2020-01-05', '17:17:23'),
(7, 1, 9, '2020-01-05', '17:29:20'),
(8, 1, 9, '2020-01-05', '14:48:37');

-- --------------------------------------------------------

--
-- Table structure for table `radnici`
--

CREATE TABLE IF NOT EXISTS `radnici` (
  `RADNIK_ID` int(11) NOT NULL AUTO_INCREMENT,
  `ULOGA_ID` int(11) DEFAULT NULL,
  `IME` varchar(30) DEFAULT NULL,
  `PREZIME` varchar(30) DEFAULT NULL,
  `KORISNICKO_IME` varchar(30) DEFAULT NULL,
  `SIFRA` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`RADNIK_ID`),
  KEY `FK_RELATIONSHIP_3` (`ULOGA_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `radnici`
--

INSERT INTO `radnici` (`RADNIK_ID`, `ULOGA_ID`, `IME`, `PREZIME`, `KORISNICKO_IME`, `SIFRA`) VALUES
(1, 3, 'Marko', 'Markovic', 'm.m', 'marko'),
(2, 2, 'Rade', 'Radenkovic', 'r.r', 'rade'),
(3, 1, 'Aca', 'Ackovic', 'a.a', 'aca');

-- --------------------------------------------------------

--
-- Table structure for table `terapija`
--

CREATE TABLE IF NOT EXISTS `terapija` (
  `TERAPIJA_ID` int(11) NOT NULL AUTO_INCREMENT,
  `PACIJENT_ID` int(11) DEFAULT NULL,
  `BOLEST_ID` int(11) DEFAULT NULL,
  `LEK_ID` int(11) DEFAULT NULL,
  `TRAJANJE` int(11) DEFAULT NULL,
  `DATUM` date DEFAULT NULL,
  PRIMARY KEY (`TERAPIJA_ID`),
  KEY `FK_RELATIONSHIP_4` (`LEK_ID`),
  KEY `FK_RELATIONSHIP_15` (`BOLEST_ID`),
  KEY `FK_RELATIONSHIP_5` (`PACIJENT_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `terapija`
--

INSERT INTO `terapija` (`TERAPIJA_ID`, `PACIJENT_ID`, `BOLEST_ID`, `LEK_ID`, `TRAJANJE`, `DATUM`) VALUES
(2, 10, 2, 1, 7, '2020-01-07'),
(3, 10, 1, 4, 8, '2020-01-04'),
(4, 10, 1, 3, 5, '2020-01-05'),
(14, 10, 2, 3, 31, '2020-01-05'),
(15, 10, 2, 4, 4, '2020-01-05'),
(16, 9, 3, 5, 10, '2020-01-05'),
(18, 10, 3, 5, 10, '2020-01-05'),
(20, 10, 4, 6, 4, '2020-01-05');

-- --------------------------------------------------------

--
-- Table structure for table `uloge`
--

CREATE TABLE IF NOT EXISTS `uloge` (
  `ULOGA_ID` int(11) NOT NULL AUTO_INCREMENT,
  `ULOGA` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`ULOGA_ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `uloge`
--

INSERT INTO `uloge` (`ULOGA_ID`, `ULOGA`) VALUES
(1, 'admin'),
(2, 'tehnicar'),
(3, 'lekar');

--
-- Constraints for dumped tables
--

--
-- Constraints for table `boluje_od`
--
ALTER TABLE `boluje_od`
  ADD CONSTRAINT `FK_RELATIONSHIP_6` FOREIGN KEY (`PACIJENT_ID`) REFERENCES `pacijenti` (`PACIJENT_ID`),
  ADD CONSTRAINT `FK_RELATIONSHIP_7` FOREIGN KEY (`BOLEST_ID`) REFERENCES `bolesti` (`BOLEST_ID`);

--
-- Constraints for table `izabrani_lekar`
--
ALTER TABLE `izabrani_lekar`
  ADD CONSTRAINT `FK_RELATIONSHIP_1` FOREIGN KEY (`PACIJENT_ID`) REFERENCES `pacijenti` (`PACIJENT_ID`),
  ADD CONSTRAINT `FK_RELATIONSHIP_2` FOREIGN KEY (`RADNIK_ID`) REFERENCES `radnici` (`RADNIK_ID`);

--
-- Constraints for table `pregledi`
--
ALTER TABLE `pregledi`
  ADD CONSTRAINT `FK_RELATIONSHIP_8` FOREIGN KEY (`RADNIK_ID`) REFERENCES `radnici` (`RADNIK_ID`),
  ADD CONSTRAINT `FK_RELATIONSHIP_9` FOREIGN KEY (`PACIJENT_ID`) REFERENCES `pacijenti` (`PACIJENT_ID`);

--
-- Constraints for table `radnici`
--
ALTER TABLE `radnici`
  ADD CONSTRAINT `FK_RELATIONSHIP_3` FOREIGN KEY (`ULOGA_ID`) REFERENCES `uloge` (`ULOGA_ID`);

--
-- Constraints for table `terapija`
--
ALTER TABLE `terapija`
  ADD CONSTRAINT `FK_RELATIONSHIP_15` FOREIGN KEY (`BOLEST_ID`) REFERENCES `bolesti` (`BOLEST_ID`),
  ADD CONSTRAINT `FK_RELATIONSHIP_4` FOREIGN KEY (`LEK_ID`) REFERENCES `lekovi` (`LEK_ID`),
  ADD CONSTRAINT `FK_RELATIONSHIP_5` FOREIGN KEY (`PACIJENT_ID`) REFERENCES `pacijenti` (`PACIJENT_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

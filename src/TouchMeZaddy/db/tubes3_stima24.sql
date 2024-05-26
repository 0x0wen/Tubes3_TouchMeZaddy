-- MySQL dump 10.13  Distrib 8.0.36, for Linux (x86_64)
--
-- Host: localhost    Database: tubes3_stima24
-- ------------------------------------------------------
-- Server version	8.0.36-0ubuntu0.22.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `biodata`
--

DROP TABLE IF EXISTS `biodata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `biodata` (
  `NIK` varchar(16) NOT NULL,
  `nama` varchar(100) DEFAULT NULL,
  `tempat_lahir` varchar(50) DEFAULT NULL,
  `tanggal_lahir` date DEFAULT NULL,
  `jenis_kelamin` enum('Laki-Laki','Perempuan') DEFAULT NULL,
  `golongan_darah` varchar(5) DEFAULT NULL,
  `alamat` varchar(255) DEFAULT NULL,
  `agama` varchar(50) DEFAULT NULL,
  `status_perkawinan` enum('Belum Menikah','Menikah','Cerai') DEFAULT NULL,
  `pekerjaan` varchar(100) DEFAULT NULL,
  `kewarganegaraan` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`NIK`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `biodata`
--

LOCK TABLES `biodata` WRITE;
/*!40000 ALTER TABLE `biodata` DISABLE KEYS */;
INSERT INTO `biodata` (`NIK`, `nama`, `tempat_lahir`, `tanggal_lahir`, `jenis_kelamin`, `golongan_darah`, `alamat`, `agama`, `status_perkawinan`, `pekerjaan`, `kewarganegaraan`) VALUES
('1234567890123456', 'John Doe', 'Jakarta', '1990-05-15', 'Laki-Laki', 'O', 'Jl. Jendral Sudirman No. 123', 'Islam', 'Belum Menikah', 'Pegawai Swasta', 'Indonesia'),
('9876543210987654', 'Jane Smith', 'Surabaya', '1995-10-20', 'Perempuan', 'A', 'Jl. Diponegoro No. 456', 'Kristen', 'Menikah', 'Wirausaha', 'Indonesia'),
('5678901234567890', 'Michael Johnson', 'Bandung', '1988-03-08', 'Laki-Laki', 'B', 'Jl. Gatot Subroto No. 789', 'Katholik', 'Cerai', 'Dokter', 'Indonesia'),
('1234567890123457', 'Maria Garcia', 'Yogyakarta', '1993-12-25', 'Perempuan', 'AB', 'Jl. Asia Afrika No. 456', 'Islam', 'Belum Menikah', 'Akuntan', 'Indonesia'),
('9876543210987653', 'David Brown', 'Semarang', '1991-08-11', 'Laki-Laki', 'A', 'Jl. Pahlawan No. 678', 'Kristen', 'Menikah', 'Pengusaha', 'Indonesia'),
('5678901234567891', 'Laura Taylor', 'Medan', '1987-06-30', 'Perempuan', 'O', 'Jl. Diponegoro No. 789', 'Protestan', 'Belum Menikah', 'Arsitek', 'Indonesia'),
('1234567890123458', 'Daniel Martinez', 'Palembang', '1985-02-18', 'Laki-Laki', 'B', 'Jl. Asia Afrika No. 234', 'Katholik', 'Menikah', 'Dosen', 'Indonesia'),
('9876543210987652', 'Sophia Wilson', 'Denpasar', '1996-09-05', 'Perempuan', 'A', 'Jl. Diponegoro No. 789', 'Islam', 'Belum Menikah', 'Desainer Grafis', 'Indonesia'),
('5678901234567892', 'James Lee', 'Makassar', '1994-04-12', 'Laki-Laki', 'AB', 'Jl. Asia Afrika No. 789', 'Protestan', 'Cerai', 'Pengacara', 'Indonesia'),
('1234567890123459', 'Emma Clark', 'Bandar Lampung', '1989-11-03', 'Perempuan', 'O', 'Jl. Jendral Sudirman No. 456', 'Katholik', 'Menikah', 'Dokter', 'Indonesia'),
('9876543210987651', 'Noah White', 'Pekanbaru', '1992-07-17', 'Laki-Laki', 'B', 'Jl. Pahlawan No. 123', 'Kristen', 'Belum Menikah', 'Insinyur', 'Indonesia'),
('5678901234567893', 'Olivia Rodriguez', 'Pontianak', '1986-05-22', 'Perempuan', 'AB', 'Jl. Gatot Subroto No. 123', 'Islam', 'Cerai', 'Pelukis', 'Indonesia'),
('1234567890123460', 'William Garcia', 'Balikpapan', '1997-01-30', 'Laki-Laki', 'A', 'Jl. Diponegoro No. 234', 'Katholik', 'Menikah', 'Pilot', 'Indonesia'),
('9876543210987650', 'Ava Martinez', 'Batam', '1990-04-08', 'Perempuan', 'O', 'Jl. Asia Afrika No. 678', 'Protestan', 'Belum Menikah', 'Penulis', 'Indonesia'),
('5678901234567894', 'Alexander Brown', 'Manado', '1988-11-15', 'Laki-Laki', 'B', 'Jl. Jendral Sudirman No. 567', 'Islam', 'Menikah', 'Arsitek', 'Indonesia'),
('1234567890123461', 'Mia Taylor', 'Padang', '1993-08-22', 'Perempuan', 'A', 'Jl. Gatot Subroto No. 345', 'Kristen', 'Belum Menikah', 'Wirausaha', 'Indonesia'),
('9876543210987649', 'Benjamin Wilson', 'Banjarmasin', '1996-03-05', 'Laki-Laki', 'AB', 'Jl. Diponegoro No. 345', 'Katholik', 'Cerai', 'Dokter Hewan', 'Indonesia'),
('5678901234567895', 'Charlotte Lee', 'Palembang', '1991-10-10', 'Perempuan', 'O', 'Jl. Pahlawan No. 456', 'Islam', 'Menikah', 'Penyiar Radio', 'Indonesia'),
('1234567890123462', 'Ethan Clark', 'Ambon', '1987-07-03', 'Laki-Laki', 'B', 'Jl. Asia Afrika No. 789', 'Protestan', 'Belum Menikah', 'Ahli IT', 'Indonesia'),
('9876543210987648', 'Isabella Rodriguez', 'Surakarta', '1995-04-20', 'Perempuan', 'A', 'Jl. Jendral Sudirman No. 678', 'Kristen', 'Menikah', 'Pelatih Olahraga', 'Indonesia');

/*!40000 ALTER TABLE `biodata` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sidik_jari`
--

DROP TABLE IF EXISTS `sidik_jari`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sidik_jari` (
  `berkas_citra` text,
  `nama` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sidik_jari`
--

LOCK TABLES `sidik_jari` WRITE;
/*!40000 ALTER TABLE `sidik_jari` DISABLE KEYS */;
INSERT INTO `sidik_jari` (`berkas_citra`, `nama`) VALUES
('iÿÿÿÿÿÿÿÿÿÿÌÿÿû:Ãÿÿ<Ìÿÿuw1', 'John Doe'),
('ûÿkÿý,Pþÿ¿/ÿÿ»ÿÿÐ¾?ÿ&¼¡¤Úª È/Zíÿÿq2', 'Jane Smith'),
('¼ÿúTý~Rûût`íÿÿÿÿÿÿ3', 'Michael Johnson'),
('iÿÿÿÿÿÿÿÿÿöÿÿÿ"býÿýÁüþÿÊ4', 'Maria Garcia'),
('ÿþ /ÿ 2ÿúYÿÿ\\ ^ÿÿp fÿÿà! ÿÿÿþÿÿÿÿÿý <ðÿÕ5', 'David Brown'),
('ÿQûÿ Nºÿá ÿÿÿÿÿÿ6', 'Sophia Wilson'),
('ûTý~Rûût`íÿÿÿÿÿÿ7', 'James Lee'),
('iÿÿÿÿÿÿÿÿÿöÿÿÿ"býÿýÁüþÿÊ8', 'Emma Clark'),
('ûTý~Rûût`íÿÿÿÿÿÿ9', 'Noah White'),
('ÿþ /ÿ 2ÿúYÿÿ\\ ^ÿÿp fÿÿà! ÿÿÿþÿÿÿÿÿý <ðÿÕ10', 'Olivia Rodriguez'),
('iÿÿÿÿÿÿÿÿÿöÿÿÿ"býÿýÁüþÿÊ11', 'William Garcia'),
('ÿþ /ÿ 2ÿúYÿÿ\\ ^ÿÿp fÿÿà! ÿÿÿþÿÿÿÿÿý <ðÿÕ12', 'Ava Martinez'),
('ûTý~Rûût`íÿÿÿÿÿÿ13', 'Alexander Brown'),
('iÿÿÿÿÿÿÿÿÿöÿÿÿ"býÿýÁüþÿÊ14', 'Mia Taylor'),
('ÿþ /ÿ 2ÿúYÿÿ\\ ^ÿÿp fÿÿà! ÿÿÿþÿÿÿÿÿý <ðÿÕ15', 'Benjamin Wilson'),
('ûTý~Rûût`íÿÿÿÿÿÿ16', 'Charlotte Lee'),
('iÿÿÿÿÿÿÿÿÿöÿÿÿ"býÿýÁüþÿÊ17', 'Ethan Clark'),
('ÿþ /ÿ 2ÿúYÿÿ\\ ^ÿÿp fÿÿà! ÿÿÿþÿÿÿÿÿý <ðÿÕ18', 'Isabella Rodriguez'),
('ûTý~Rûût`íÿÿÿÿÿÿ19', 'Daniel Martinez'),
('iÿÿÿÿÿÿÿÿÿöÿÿÿ"býÿýÁüþÿÊ20', 'Sophia Wilson');
/*!40000 ALTER TABLE `sidik_jari` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-05-04 15:57:34

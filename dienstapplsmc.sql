-- phpMyAdmin SQL Dump
-- version 4.6.6deb4
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Erstellungszeit: 23. Mai 2019 um 17:09
-- Server-Version: 10.1.38-MariaDB-0+deb9u1
-- PHP-Version: 7.0.33-0+deb9u3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Datenbank: `LSMCDienstApp`
--

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Archiv`
--

CREATE TABLE `Archiv` (
  `id` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `austritt` date NOT NULL,
  `bemerkung` text NOT NULL,
  `entlassen` int(1) NOT NULL DEFAULT '0' COMMENT '0 = Nein, 1 = Ja',
  `gemeldet` int(1) NOT NULL DEFAULT '0' COMMENT '0 = Nein, 1 = Ja',
  `dokumente` int(1) NOT NULL DEFAULT '0' COMMENT '0 = Nein, 1 = Ja',
  `wiedereingestellt` int(1) NOT NULL DEFAULT '0' COMMENT '0 = Nein, 1 = Ja',
  `blacklist` int(1) NOT NULL DEFAULT '0' COMMENT '0 = Nein, 1 = Ja',
  `beitritt` date NOT NULL,
  `rang` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Archiv`
--

INSERT INTO `Archiv` (`id`, `userid`, `austritt`, `bemerkung`, `entlassen`, `gemeldet`, `dokumente`, `wiedereingestellt`, `blacklist`, `beitritt`, `rang`) VALUES
(8, 38563, '2019-01-30', '', 0, 0, 0, 0, 0, '2019-01-18', 12),
(9, 40499, '2019-02-02', 'Testzugang', 0, 0, 0, 0, 0, '2019-02-02', 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `AusbildungsTermine`
--

CREATE TABLE `AusbildungsTermine` (
  `id` int(11) NOT NULL,
  `prüfling` varchar(30) NOT NULL,
  `prüfung` varchar(30) NOT NULL,
  `uhrzeit` varchar(20) NOT NULL,
  `wochentage` text NOT NULL,
  `prüfer` varchar(30) NOT NULL,
  `termin` text NOT NULL,
  `status` int(1) NOT NULL DEFAULT '0' COMMENT '0 = Anfrage | 1=Termin bekommen | 2 = Termin bestätigt | 3 = Termin abgelehnt | 4 = Termin abgebrochen | 5 = beendet'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `AusbildungsTermine`
--

INSERT INTO `AusbildungsTermine` (`id`, `prüfling`, `prüfung`, `uhrzeit`, `wochentage`, `prüfer`, `termin`, `status`) VALUES
(15, 'Luca_Bernegger', 'EST', '16:00 - 20:00', 'Montag,Samstag,', 'Luca_Bernegger', '29.12.2018  -  18:00', 5),
(16, 'Luca_Bernegger', 'Approbation Fragen', '16:00 - 20:00', 'Dienstag,Samstag,', 'Luca_Bernegger', '25.12.2018  -  17:21', 5),
(17, 'Luca_Bernegger', 'EST', '16:00 - 20:00', 'Mittwoch,Samstag,', 'Luca_Bernegger', '26.12.2018  -  20:00', 5),
(18, 'Max_Murdock', 'EST', '00:01 - 23:59', 'Samstag,Samstag,', '', '', 0),
(19, 'Alfons_Nightwalker', '', '16:00 - 20:00', 'Mittwoch,Samstag,', '', '', 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Beladung`
--

CREATE TABLE `Beladung` (
  `id` int(11) NOT NULL,
  `itemname` varchar(30) NOT NULL,
  `Anzahl` int(11) NOT NULL,
  `atkiv` tinyint(4) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Beladung`
--

INSERT INTO `Beladung` (`id`, `itemname`, `Anzahl`, `atkiv`) VALUES
(1, 'Nadel und Faden', 10, 1),
(2, 'Verband', 10, 1),
(3, 'Steriele Auflage', 10, 1),
(4, 'Dr. Teddy', 10, 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `BewerbungFallbeispiele`
--

CREATE TABLE `BewerbungFallbeispiele` (
  `id` int(11) NOT NULL,
  `beispiel` text NOT NULL,
  `richtig` text NOT NULL,
  `aktiv` int(11) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `BewerbungFallbeispiele`
--

INSERT INTO `BewerbungFallbeispiele` (`id`, `beispiel`, `richtig`, `aktiv`) VALUES
(1, 'In einem Keller finden Sie eine typische \"Partysituation\" vor. Es liegen viele Bierdosen herum und auch einiges an Hochprozentigen ist vorhanden. Der Patient liegt in stabiler Seitenlage auf dem Boden und führt kurze, dichtaufeinanderfolgende Atemzüge bei offenem Mund aus. ', 'Sauerstoff - an die frische Luft ', 1),
(2, 'Im einem Stall finden Sie einen, auf einem Strohballen sitzenden Patienten vor, der über starke Bauchschmerzen klagt. Der Tierarzt ist beim Versuch Kühe zu impfen von einem Tier mehrfach getreten worden.', 'innere Verletzungen - schneller Abtransport', 1),
(3, 'Am Einsatzort finden Sie eine stehende Person vor, die sich seine blutende und schmerzende Hand hält. Bei der Flucht von einem Firmengelände, versuchte der Einbrecher über den Zaun zu klettern stürzte aber ab. Dabei wurde ihm der kleine Finger von der Hand abgerissen.', 'Finger mitnehmen - Druckverband - ggf. Polizei', 1),
(4, 'Am Einsatzort angekommen führt Sie eine aufgeregte Person in den Garten zu einem Patienten, der sich mit schmerzverzerrtem Gesicht nur mühsam auf den Beinen halten kann. In einem Fuß stecken durch den Schuh hindurch die Krallen einer massiven Gartenharke mit einem etwa 1.5 m langen Griff. Der Patient ist aus Unachtsamkeit in die auf dem Gartenweg liegende Harke getreten.', 'Harke nicht entfernen', 1),
(5, 'Sie werden zu einem Einsatz auf dem Mount Chilliad gerufen:\"Meine Frau ist beim Wandern schwer umgeknickt und kann nicht mehr laufen.\"Was tun Sie?', 'Betroffenes Bein schienen/ Im Kh röntgen lassen', 1),
(6, 'Sie bekommen einen Notruf:\"Mein Kumpel ist betrunken und ist auf die Straße gelaufen und wurde angefahren. Er ist nicht mehr ansprechbar und reagiert auf garnichts!Was soll ich tun!', 'Infusion legen/Beatmung durch Atemmaske', 1),
(7, 'Sie kommen an ihrem Einsatzort an und finden eine unter Schock stehende Person an.Die Person reagiert nicht auf sie und fällt von jetzt auf gleich in Ohnmacht und führt dabei kurze aufeinander folgende Atemzüge durch.Ihnen fällt auf das die Person sehr schwer am Handgelenk blutet. Was tun sie?', 'Infusion-Sauerstoff-Handgelenk behandeln-Umgehend ins Krankenhaus', 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Bewerbungstermine`
--

CREATE TABLE `Bewerbungstermine` (
  `id` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `forumsname` varchar(50) NOT NULL,
  `userid` int(11) NOT NULL,
  `telnummer` int(11) NOT NULL,
  `Datum` varchar(10) NOT NULL,
  `Uhrzeit` varchar(10) NOT NULL,
  `aktiv` tinyint(4) NOT NULL DEFAULT '1',
  `status` tinyint(4) NOT NULL DEFAULT '1' COMMENT '1= Eingeladen 2= Angenommen 3 = Abgelehnt'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Bewerbungstermine`
--

INSERT INTO `Bewerbungstermine` (`id`, `name`, `forumsname`, `userid`, `telnummer`, `Datum`, `Uhrzeit`, `aktiv`, `status`) VALUES
(9, 'Test_Max', 'aspfa', 123, 456, '23.11.2018', '10', 0, 3),
(10, 'hfh_ada', '11', 11, 11, '23.11.2018', '10', 0, 2),
(11, 'gdg_ad', '123', 123, 123, '23.11.2018', '123', 0, 4),
(12, 'Synex_Samas', 'Synex', 44210, 39383, '30.01.2019', '20:00', 0, 2),
(13, 'Paul_Kalim', 'EliteGamer92', 64864, 61735, '30.01.2019', '20', 0, 2);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Changelog`
--

CREATE TABLE `Changelog` (
  `id` int(11) NOT NULL,
  `titel` text NOT NULL,
  `text` text NOT NULL,
  `datum` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Changelog`
--

INSERT INTO `Changelog` (`id`, `titel`, `text`, `datum`) VALUES
(1, 'Changelog', '- Wie der Titel schon sagt wird es ab Heute in dem Tool Changelogs geben, welche euch über Fixes und Neuerungen im Dienstapp Klarheit verschaffen sollen.\n- Bei Rückfragen könnt Ihr jederzeit zu Mike_Mathews kommen.', '2019-02-01 22:29:56'),
(2, 'Urlaubsantrag - Urlaubsliste', '- Urlaubsantrag: Nach Meldung des Bugs dass man in der Vergangenheit Urlaub beantragen kann wurde dies behoben.\n- Urlaubsantrag: Wählt man ein Datum aus so wird das passende Minimumenddatum ausgewählt und wählbar gemacht.\n- Urlaubsantrag: Begründung darf nicht leer oder Begründung stehen sondern muss ausgefüllt werden.\n\n- Urlaubsliste: Wenn beim Urlaubsantrag der Punkt \"Begründung anzeigen\" deaktiviert ist so wird nur noch der Urlaub aber keine Begründung angezeigt.\n- Urlaubsliste: Es werden nur noch Offene Urlaube angezeigt.', '2019-02-04 07:37:38');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Dienstzeit`
--

CREATE TABLE `Dienstzeit` (
  `id` int(11) NOT NULL,
  `user` int(11) NOT NULL,
  `eingetragen` timestamp NULL DEFAULT NULL,
  `ausgetragen` timestamp NULL DEFAULT NULL,
  `aktivitaet` int(11) NOT NULL COMMENT '0 = Aktiv, 1 = Inaktiv, 2 = S0, 3 = S1, 4 = S2, 5 = S3, 6 = S4, 7 = S5, 8 = S6, 9 = S7, 10 = ID, 11 = Leitstelle, 12 = Besprechung, 13 = Bewerbung, 14 = Buero, 15 = Event, 16 = Fortbildung, 17 = FST, 18 = Pruefung, 19 = Verwaltung, 20 = EHK, 21 = A-Duty, 22 = Einweisung',
  `fahrzeug` text NOT NULL,
  `funk` text NOT NULL,
  `notiz` text NOT NULL,
  `patient` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Dienstzeit`
--

INSERT INTO `Dienstzeit` (`id`, `user`, `eingetragen`, `ausgetragen`, `aktivitaet`, `fahrzeug`, `funk`, `notiz`, `patient`) VALUES
(1, 39082, '2019-01-30 16:28:43', '2019-01-30 16:29:13', 0, 'RTW-2770', '1010', '', ''),
(2, 16324, '2019-01-30 16:29:16', '2019-01-30 16:30:15', 0, 'NEF-2594', '1010', '', ''),
(3, 39082, '2019-01-30 16:29:29', '2019-01-30 16:30:50', 0, 'RTW-2770', '1010', '', ''),
(4, 16324, '2019-01-30 16:31:00', '2019-01-30 16:32:02', 0, 'RTW-2770', '1010', '', ''),
(5, 72901, '2019-01-30 16:32:41', '2019-01-30 16:35:13', 0, 'NEF-2590', '1010', '', ''),
(6, 39082, '2019-01-30 16:32:43', '2019-01-30 16:33:15', 2, 'KdoW-2107', '1010.1', '', ''),
(7, 39082, '2019-01-30 16:33:48', '2019-01-30 16:33:54', 0, 'NEF-2589', 'AUS', '', ''),
(8, 39082, '2019-01-30 16:34:18', '2019-01-30 16:35:13', 0, 'NEF-2590', 'AUS', '', ''),
(9, 62827, '2019-01-30 16:34:24', '2019-01-30 16:35:13', 0, 'NEF-2590', '1010', '', ''),
(10, 16324, '2019-01-30 16:36:38', '2019-01-30 16:36:49', 7, 'NEF-2595', 'AUS', '', ''),
(11, 16324, '2019-01-30 16:36:51', '2019-01-30 16:52:04', 7, 'NEF-2595', '1010', '', ''),
(12, 19920, '2019-01-30 20:37:32', '2019-01-31 16:20:41', 0, 'LG-1911', '1010', '', ''),
(13, 72901, '2019-01-31 15:49:46', '2019-01-31 15:51:28', 0, 'NEF-2587', '1010', '', ''),
(14, 72901, '2019-01-31 15:59:20', '2019-01-31 16:00:48', 10, 'Krankenhaus 1', 'AUS', '', ''),
(15, 72901, '2019-01-31 16:02:16', '2019-01-31 16:06:06', 10, 'Krankenhaus 1', 'AUS', '', ''),
(16, 62827, '2019-01-31 16:02:53', '2019-01-31 16:03:06', 0, 'Krankenhaus 1', 'AUS', '', ''),
(17, 42125, '2019-01-31 16:03:10', '2019-01-31 16:03:25', 0, 'RTW-2781', '1010', '', ''),
(18, 42125, '2019-01-31 16:03:30', '2019-01-31 16:03:44', 0, 'RTW-2781', '1010', '', ''),
(19, 62827, '2019-01-31 16:03:33', '2019-01-31 16:03:46', 20, 'NEF-2587', 'AUS', '', ''),
(20, 72901, '2019-01-31 16:06:16', '2019-01-31 16:08:56', 16, 'Krankenhaus 1', 'AUS', '', ''),
(21, 42125, '2019-01-31 16:07:15', '2019-01-31 16:07:30', 0, 'RTW-2781', 'AUS', '', ''),
(22, 42125, '2019-01-31 16:07:35', '2019-01-31 16:09:35', 0, 'RTW-2781', '1010', '', ''),
(23, 72901, '2019-01-31 16:09:06', '2019-01-31 16:09:46', 3, 'RTB-2129', '1010', '', ''),
(24, 62827, '2019-01-31 16:11:34', '2019-01-31 16:11:46', 2, 'KdoW-2106', 'AUS', '', ''),
(25, 62827, '2019-01-31 16:12:47', '2019-01-31 16:13:10', 0, 'KdoW-2106', 'AUS', '', ''),
(26, 62827, '2019-01-31 16:14:42', '2019-01-31 16:14:52', 0, 'KdoW-2106', 'AUS', '', ''),
(27, 62827, '2019-01-31 16:18:22', '2019-01-31 16:18:30', 0, 'KdoW-2106', 'AUS', '', ''),
(28, 62827, '2019-01-31 16:19:18', '2019-01-31 16:19:28', 0, 'KdoW-2106', 'AUS', '', ''),
(29, 42125, '2019-01-31 16:19:36', '2019-01-31 16:20:41', 9, 'LG-1911', 'AUS', '', ''),
(30, 19920, '2019-01-31 16:20:41', '2019-01-31 19:34:01', 0, 'RTW-2781', '1010', '', ''),
(31, 42125, '2019-01-31 16:20:51', '2019-01-31 16:21:41', 0, 'RTW-2781', '1010', '', ''),
(32, 62827, '2019-01-31 16:21:13', '2019-01-31 16:21:33', 0, 'KdoW-2106', 'AUS', '', ''),
(33, 62827, '2019-01-31 16:21:54', '2019-01-31 16:23:44', 5, 'KdoW-2106', 'AUS', '', ''),
(34, 62827, '2019-01-31 16:23:22', '2019-01-31 16:23:44', 0, 'KdoW-2106', 'AUS', '', ''),
(35, 62827, '2019-01-31 16:23:47', '2019-01-31 16:25:03', 3, 'KdoW-2106', 'AUS', '', ''),
(36, 62827, '2019-01-31 16:25:08', '2019-02-01 23:31:57', 0, 'KdoW-2106', 'AUS', '', ''),
(37, 56086, '2019-01-31 16:58:01', '2019-01-31 16:58:12', 0, 'RTW-2777', '1010', '', ''),
(38, 56086, '2019-01-31 16:58:14', '2019-01-31 16:58:40', 0, 'RTW-2777', '1010', '', ''),
(39, 56086, '2019-01-31 16:58:42', '2019-01-31 16:58:53', 9, 'RTW-2777', 'AUS', '', ''),
(40, 56086, '2019-01-31 16:58:55', '2019-01-31 16:59:20', 2, 'RTW-2777', 'AUS', '', ''),
(41, 56086, '2019-01-31 16:59:22', '2019-01-31 16:59:40', 11, 'RTW-2777', 'AUS', '', ''),
(42, 56086, '2019-01-31 16:59:46', '2019-01-31 16:59:56', 0, 'RTW-2777', 'AUS', '', ''),
(43, 19920, '2019-01-31 19:34:04', '2019-01-31 23:57:39', 0, 'RTH-2585', '1010', '', ''),
(44, 42125, '2019-02-01 07:06:55', '2019-02-01 07:37:18', 0, 'RTW-2781', '1010', '', ''),
(45, 42125, '2019-02-01 07:37:25', '2019-02-01 07:37:41', 0, 'RTW-2781', '1010', '', ''),
(46, 42125, '2019-02-01 07:37:46', '2019-02-01 07:38:02', 8, 'RTW-2781', 'AUS', '', ''),
(47, 42125, '2019-02-01 07:38:10', '2019-02-01 07:38:18', 12, 'RTW-2781', 'AUS', '', ''),
(48, 40499, '2019-02-01 23:30:46', '2019-02-01 23:31:52', 0, 'KdoW-2107', '1000', '', ''),
(49, 40499, '2019-02-01 23:31:53', NULL, 0, 'KdoW-2107', '1000', '', ''),
(50, 62827, '2019-02-01 23:32:04', NULL, 3, 'KdoW-2106', 'AUS', '', ''),
(51, 92485, '2019-02-02 15:25:03', '2019-02-02 17:16:13', 0, 'RTW-2766', '1010', '', ''),
(52, 92485, '2019-02-03 15:46:59', '2019-02-03 19:55:55', 0, 'RTW-2766', '1010', '', ''),
(53, 92485, '2019-02-04 09:27:21', '2019-02-04 09:28:43', 0, 'RTW-2766', '1010', '', ''),
(54, 16324, '2019-02-04 09:27:54', '2019-02-04 09:28:43', 0, 'RTW-2766', '1010', '', ''),
(55, 92485, '2019-02-04 15:32:56', '2019-02-04 16:50:38', 0, 'RTW-2558', '1010', '', '');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `FahrzeugbeladungArchiv`
--

CREATE TABLE `FahrzeugbeladungArchiv` (
  `id` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `link` text NOT NULL,
  `gefehlt` text NOT NULL,
  `woche` int(2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `FahrzeugbeladungArchiv`
--

INSERT INTO `FahrzeugbeladungArchiv` (`id`, `name`, `link`, `gefehlt`, `woche`) VALUES
(1, 'Luca_Bernegger', 'asdasdasd', '5 Gips', 47);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Fahrzeuge`
--

CREATE TABLE `Fahrzeuge` (
  `nummer` int(5) NOT NULL,
  `typ` varchar(10) NOT NULL,
  `letzterfahrer` varchar(30) DEFAULT ' ',
  `kontroliert` varchar(30) DEFAULT ' ' COMMENT 'Name;Datum',
  `beladung` text,
  `aktiv` tinyint(4) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Fahrzeuge`
--

INSERT INTO `Fahrzeuge` (`nummer`, `typ`, `letzterfahrer`, `kontroliert`, `beladung`, `aktiv`) VALUES
(142, 'TLF', ' ', ' ', NULL, 1),
(144, 'TLF', 'Luca_Bernegger', 'Luca_Bernegger;22.11.2018', '1:10;2:5;3:1;4:0;', 1),
(1909, 'LG', ' ', ' ', NULL, 1),
(1910, 'LG', ' ', ' ', NULL, 1),
(1911, 'LG', ' ', ' ', NULL, 1),
(2106, 'KdoW', ' ', ' ', NULL, 1),
(2107, 'KdoW', ' ', ' ', NULL, 1),
(2108, 'KdoW', ' ', ' ', NULL, 1),
(2109, 'KdoW', ' ', ' ', NULL, 1),
(2110, 'KdoW', ' ', ' ', NULL, 1),
(2116, 'RTH', ' ', ' ', NULL, 1),
(2117, 'RTH', ' ', ' ', NULL, 1),
(2118, 'RTH', ' ', ' ', NULL, 1),
(2119, 'RTH', ' ', ' ', NULL, 1),
(2125, 'RTH', ' ', ' ', NULL, 1),
(2126, 'RTB', ' ', ' ', NULL, 1),
(2127, 'RTB', ' ', ' ', NULL, 1),
(2128, 'RTB', ' ', ' ', NULL, 1),
(2129, 'RTB', ' ', ' ', NULL, 1),
(2558, 'RTW', ' ', ' ', NULL, 1),
(2559, 'RTW', ' ', ' ', NULL, 1),
(2571, 'RTH', ' ', ' ', NULL, 1),
(2575, 'RTH', ' ', ' ', NULL, 1),
(2576, 'RTH', ' ', ' ', NULL, 1),
(2582, 'RTH', ' ', ' ', NULL, 1),
(2584, 'RTH', ' ', ' ', NULL, 1),
(2585, 'RTH', ' ', ' ', NULL, 1),
(2586, 'RTH', ' ', ' ', NULL, 1),
(2587, 'NEF', ' ', ' ', NULL, 1),
(2588, 'NEF', ' ', ' ', NULL, 1),
(2589, 'NEF', ' ', ' ', NULL, 1),
(2590, 'NEF', ' ', ' ', NULL, 1),
(2591, 'NEF', ' ', ' ', NULL, 1),
(2592, 'NEF', ' ', ' ', NULL, 1),
(2593, 'NEF', ' ', ' ', NULL, 1),
(2594, 'NEF', ' ', ' ', NULL, 1),
(2595, 'NEF', ' ', ' ', NULL, 1),
(2764, 'RTW', ' ', ' ', NULL, 1),
(2765, 'RTW', ' ', ' ', NULL, 1),
(2766, 'RTW', ' ', ' ', NULL, 1),
(2767, 'RTW', ' ', ' ', NULL, 1),
(2768, 'RTW', ' ', ' ', NULL, 1),
(2769, 'RTW', ' ', ' ', NULL, 1),
(2770, 'RTW', ' ', ' ', NULL, 1),
(2771, 'RTW', ' ', ' ', NULL, 1),
(2772, 'RTW', ' ', ' ', NULL, 1),
(2773, 'RTW', ' ', ' ', NULL, 1),
(2774, 'RTW', ' ', ' ', NULL, 1),
(2775, 'RTW', ' ', ' ', NULL, 1),
(2776, 'RTW', ' ', ' ', NULL, 1),
(2777, 'RTW', ' ', ' ', NULL, 1),
(2778, 'RTW', ' ', ' ', NULL, 1),
(2779, 'RTW', ' ', ' ', NULL, 1),
(2780, 'RTW', ' ', ' ', NULL, 1),
(2781, 'RTW', ' ', ' ', NULL, 1),
(2782, 'RTW', ' ', 'Luca_Bernegger;22.11.2018', '1:0;2:5;3:0;4:0;', 1),
(2783, 'RTW', ' ', 'Luca_Bernegger;22.11.2018', '1:0;2:0;3:1;4:0;', 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Fahrzeug_Einsatz`
--

CREATE TABLE `Fahrzeug_Einsatz` (
  `id` int(11) NOT NULL,
  `vehid` int(11) NOT NULL,
  `eingetragen` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `ausgetragen` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00',
  `pssenger1` int(11) NOT NULL,
  `passenger2` int(11) NOT NULL,
  `passenger3` int(11) NOT NULL,
  `passenger4` int(11) NOT NULL,
  `status` int(11) NOT NULL,
  `notiz` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Freistellung`
--

CREATE TABLE `Freistellung` (
  `id` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `name` text NOT NULL,
  `beginn` timestamp NULL DEFAULT NULL,
  `ende` timestamp NULL DEFAULT NULL,
  `aufgehoben` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Freistellung`
--

INSERT INTO `Freistellung` (`id`, `userid`, `name`, `beginn`, `ende`, `aufgehoben`) VALUES
(2, 62827, 'Luca_Bernegger', '0000-00-00 00:00:00', '0000-00-00 00:00:00', 0),
(3, 62827, 'Luca_Bernegger', '2019-01-26 13:35:19', '2019-01-26 15:35:19', 0),
(4, 62827, 'Luca_Bernegger', '2019-01-26 23:27:59', '2019-01-26 23:37:54', 62827),
(5, 62827, 'Tim_Taylor', '2019-01-26 23:29:40', '2019-01-26 23:38:15', 62827),
(6, 27892, 'Davvad_Freitag', '2019-01-27 00:12:22', '2019-01-27 00:15:20', 28108),
(7, 28108, 'Luca_Bernegger', '2019-01-27 00:13:45', '2019-01-27 00:15:35', 27892),
(8, 62827, 'Max_Murdock', '2019-01-28 15:57:57', '2019-01-30 07:56:19', 62827);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `FST`
--

CREATE TABLE `FST` (
  `id` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `fst` text NOT NULL,
  `pruefer` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `FST`
--

INSERT INTO `FST` (`id`, `userid`, `fst`, `pruefer`) VALUES
(1, 28108, 'RTW', '27892'),
(2, 15947, 'RTH', '28108'),
(3, 27892, 'RTW', '27892'),
(4, 28108, 'RTW', '28108'),
(5, 28108, 'RTW', '15947');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `FSTListe`
--

CREATE TABLE `FSTListe` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `aktiv` tinyint(4) NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `FSTListe`
--

INSERT INTO `FSTListe` (`id`, `name`, `aktiv`) VALUES
(1, 'RTW', 1),
(2, 'RTH', 1),
(3, 'RTB', 1),
(4, 'NEF', 1),
(5, 'FD', 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `mdw`
--

CREATE TABLE `mdw` (
  `id` int(11) NOT NULL,
  `username` varchar(30) NOT NULL,
  `vorschlag1` varchar(30) NOT NULL,
  `vorschlag2` varchar(30) NOT NULL,
  `vorschlag3` varchar(30) NOT NULL,
  `kw` int(11) NOT NULL,
  `jahr` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `mdw`
--

INSERT INTO `mdw` (`id`, `username`, `vorschlag1`, `vorschlag2`, `vorschlag3`, `kw`, `jahr`) VALUES
(2, 'Luca_Bernegger', 'Davvad_Freitag', 'Rene_Aeon', '', 49, 2018),
(3, 'Davvad_Freitag', 'Davvad_Freitag', 'Davvad_Freitag', 'Davvad_Freitag', 50, 2018),
(4, 'Luca_Bernegger', 'Paul_Kruse', 'Max_Mustermann', '', 50, 2018),
(5, 'Alfons_Nightwalker', 'OnkelRocky_Wacholsky', 'Zoey_Night', 'Marc_Ferus', 5, 2019),
(6, 'Marc_Ferus', 'OnkelRocky_Wacholsky', 'Paul_Kalim', 'Paco_Aydin', 5, 2019),
(7, 'Kerry_Night', 'Paco_Aydin', 'Andreas_Theke', 'Alfons_Nightwalker', 5, 2019);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `motd`
--

CREATE TABLE `motd` (
  `nachricht` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `motd`
--

INSERT INTO `motd` (`nachricht`) VALUES
('Wir befinden uns Aktuell in der Closed Alpha');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Patientenliste`
--

CREATE TABLE `Patientenliste` (
  `id` int(11) NOT NULL,
  `patient` text NOT NULL,
  `rtw` text NOT NULL,
  `angenommen` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `ausgetragen` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Pruefungen`
--

CREATE TABLE `Pruefungen` (
  `id` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `pruefung` text NOT NULL,
  `bestanden` int(1) NOT NULL COMMENT '0 = Nein, 1 = Ja',
  `bemerkung` text NOT NULL COMMENT 'Bei Appro Theorie die ANzahl der Fragen, Bei Appro Praxis die Prozent',
  `pruefer` text NOT NULL COMMENT 'Bei mehreren Prüfern beim Eintragen Trennung mit " & " und es werden nur Userids von den prüfern eingetragen'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Pruefungen`
--

INSERT INTO `Pruefungen` (`id`, `userid`, `pruefung`, `bestanden`, `bemerkung`, `pruefer`) VALUES
(1, 28108, 'Einweisung', 1, '', '62827 & 27892'),
(2, 28108, 'Approbation Fragen', 1, '30', '62827 & 27892'),
(3, 28108, 'EST', 0, '', '27892 & 22429'),
(4, 28108, 'EST', 1, '', '27892 & 22429');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Pruefungsliste`
--

CREATE TABLE `Pruefungsliste` (
  `id` int(11) NOT NULL,
  `name` text NOT NULL COMMENT 'Wie heißt die Prüfung',
  `anzpers` int(1) NOT NULL COMMENT 'Wieviele Prüfer sind von nöten',
  `aktiv` int(1) NOT NULL COMMENT '0 = Nein, 1 = Ja',
  `sonderbemerkung` text NOT NULL COMMENT 'Wenn leer wird es nicht beachtet, wenn befüllt ist es eine weitere Zeile die als Bemerkung in Pruefungen gewertet wird.'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Pruefungsliste`
--

INSERT INTO `Pruefungsliste` (`id`, `name`, `anzpers`, `aktiv`, `sonderbemerkung`) VALUES
(1, 'Einweisung', 4, 1, ''),
(2, 'EST', 2, 1, ''),
(3, 'RTWSolo', 1, 1, ''),
(4, 'Innendienst', 2, 1, ''),
(5, 'Approbation Fragen', 3, 1, 'richtig/30'),
(6, 'Approbation Theorie', 3, 1, '%'),
(7, 'Approbation Praxis', 3, 1, '%'),
(8, 'LST-Qualifikaiton', 2, 1, '');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `rankupBedinungen`
--

CREATE TABLE `rankupBedinungen` (
  `rang` int(2) NOT NULL,
  `prüfungen` text NOT NULL,
  `schulungen` text NOT NULL,
  `wochen` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `rankupBedinungen`
--

INSERT INTO `rankupBedinungen` (`rang`, `prüfungen`, `schulungen`, `wochen`) VALUES
(1, 'Einweisung;EST;', '', 2),
(2, 'Einweisung;EST;', '', 2),
(3, 'Einweisung;EST;', 'TV;Funk;', 2),
(4, 'Einweisung;EST;Innendienst;', 'TV;Funk;', 2),
(5, 'Einweisung;EST;Innendienst;', 'TV;Funk;', 2),
(6, 'Einweisung;EST;Innendienst;Approbation Fragen;Approbation Theorie;Approbation Praxis;', 'TV;Funk;', 3),
(7, 'Einweisung;EST;Innendienst;Approbation Fragen;Approbation Theorie;Approbation Praxis;', 'TV;Funk;', 3),
(8, 'Einweisung;EST;Innendienst;Approbation Fragen;Approbation Theorie;Approbation Praxis;', 'TV;Funk;', 3),
(9, 'Einweisung;EST;Innendienst;Approbation Fragen;Approbation Theorie;Approbation Praxis;', 'TV;Funk;', 0),
(10, 'Einweisung;EST;Innendienst;Approbation Fragen;Approbation Theorie;Approbation Praxis;', 'TV;Funk;', 0),
(11, 'Einweisung;EST;Innendienst;Approbation Fragen;Approbation Theorie;Approbation Praxis;', 'TV;Funk;', 0),
(12, 'Einweisung;EST;Innendienst;Approbation Fragen;Approbation Theorie;Approbation Praxis;', 'TV;Funk;', 0);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Sanktionen`
--

CREATE TABLE `Sanktionen` (
  `id` int(11) NOT NULL,
  `username` varchar(30) NOT NULL,
  `sanktion` int(11) NOT NULL,
  `strafe` int(11) NOT NULL,
  `datum` date NOT NULL,
  `aktiv` int(1) NOT NULL DEFAULT '1' COMMENT '1 = nicht bezahlt | 2 = bezahlt | 3 = ausgeblendet'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Sanktionen`
--

INSERT INTO `Sanktionen` (`id`, `username`, `sanktion`, `strafe`, `datum`, `aktiv`) VALUES
(6, 'Luca_Bernegger', 6, 0, '2018-12-25', 3),
(7, 'Luca_Bernegger', 7, 4500, '2018-12-25', 3),
(8, 'Davvad_Freitag', 7, 4500, '2018-12-26', 3),
(9, 'Davvad_Freitag', 6, 10, '2018-12-26', 3);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Schulungen`
--

CREATE TABLE `Schulungen` (
  `id` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `schulung` text NOT NULL,
  `pruefer` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Schulungen`
--

INSERT INTO `Schulungen` (`id`, `userid`, `schulung`, `pruefer`) VALUES
(4, 28108, 'TV', '28108'),
(5, 28108, 'Funk', '62827');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Schulungsliste`
--

CREATE TABLE `Schulungsliste` (
  `id` int(11) NOT NULL,
  `name` varchar(20) NOT NULL,
  `aktiv` tinyint(4) NOT NULL COMMENT '1=Ja 0=Nein'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Schulungsliste`
--

INSERT INTO `Schulungsliste` (`id`, `name`, `aktiv`) VALUES
(1, 'TV', 1),
(2, 'Funk', 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Schwarzes_Brett`
--

CREATE TABLE `Schwarzes_Brett` (
  `id` int(11) NOT NULL,
  `type` int(11) NOT NULL COMMENT '0 = Info, 1 = Anweisung',
  `eintrag` text NOT NULL,
  `eingetragen` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `autor` int(11) NOT NULL,
  `aktiv` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Schwarzes_Brett`
--

INSERT INTO `Schwarzes_Brett` (`id`, `type`, `eintrag`, `eingetragen`, `autor`, `aktiv`) VALUES
(1, 0, 'Meldet sämtliche Fehler die Ihr findet im Bugtracker. Mit genauer Fehlerbeschreibung.', '2019-01-30 16:36:48', 62827, 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Strafkatalog`
--

CREATE TABLE `Strafkatalog` (
  `id` int(11) NOT NULL,
  `Vergehen` varchar(50) NOT NULL,
  `Typ` tinyint(4) NOT NULL COMMENT '1 = leicht | 2= minimalschwer | 3 = mittelschwer | 4 = schwer ',
  `Punkte` int(11) NOT NULL,
  `Geld` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Strafkatalog`
--

INSERT INTO `Strafkatalog` (`id`, `Vergehen`, `Typ`, `Punkte`, `Geld`) VALUES
(6, 'dfhdfh', 2, 10, '10;10;10;10'),
(7, 'v', 1, 3, '600;1200;3300;4500');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `updownrank`
--

CREATE TABLE `updownrank` (
  `id` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `datum` date NOT NULL,
  `rang` int(2) NOT NULL,
  `art` text NOT NULL,
  `bemerkung` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `updownrank`
--

INSERT INTO `updownrank` (`id`, `userid`, `datum`, `rang`, `art`, `bemerkung`) VALUES
(1, 15947, '2019-01-30', 9, 'Abteilung', '');

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `Urlaub`
--

CREATE TABLE `Urlaub` (
  `id` int(11) NOT NULL,
  `name` varchar(40) NOT NULL,
  `von` date NOT NULL,
  `bis` date NOT NULL,
  `begründung` text NOT NULL,
  `veröffentlichen` tinyint(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `Urlaub`
--

INSERT INTO `Urlaub` (`id`, `name`, `von`, `bis`, `begründung`, `veröffentlichen`) VALUES
(1, 'Paul_Kruse', '2019-01-08', '2019-01-17', 'Haha', 1),
(2, 'Alfons_Nightwalker', '0000-00-00', '0000-00-00', 'Test', 1),
(3, 'Alfons_Nightwalker', '0000-00-00', '0000-00-00', 'noch nen Test', 1),
(4, 'Mike_Mathews', '0000-00-00', '0000-00-00', 'Begründung', 1),
(5, 'Mike_Mathews', '2019-02-04', '2019-02-07', 'Begründung', 0),
(6, 'Mike_Mathews', '2019-02-01', '2019-02-03', 'test123', 1),
(7, 'Mike_Mathews', '0000-00-00', '0000-00-00', 'Begründung', 1),
(8, 'Mike_Mathews', '0000-00-00', '0000-00-00', 'Test123', 1),
(9, 'Mike_Mathews', '0000-00-00', '0000-00-00', 'So eine Nase', 1),
(10, 'Mike_Mathews', '2019-02-04', '2019-02-06', 'egsg', 1),
(11, 'Mike_Mathews', '2019-02-22', '2019-02-24', 'rherh', 1),
(12, 'Alfons_Nightwalker', '2019-02-04', '2020-04-05', 'Hier steht eine Begründung', 1);

-- --------------------------------------------------------

--
-- Tabellenstruktur für Tabelle `User`
--

CREATE TABLE `User` (
  `apikey` varchar(32) NOT NULL,
  `id` int(11) NOT NULL,
  `username` text NOT NULL,
  `forumname` text NOT NULL,
  `beitritt` date NOT NULL,
  `telefon` int(11) NOT NULL,
  `rang` int(2) NOT NULL,
  `email` text,
  `abteilung` int(11) NOT NULL DEFAULT '0' COMMENT '0 = Keine, 1 = Personal, 2 = Ausbilder, 3 = EHK, 4=Membersprecher',
  `aktiv` int(1) NOT NULL COMMENT '0 = Nicht angestell, 1 = Angestellt',
  `ausbilderBemerkung` text NOT NULL,
  `personalBemerkung` text NOT NULL,
  `uninvite` int(1) NOT NULL,
  `hwid` varchar(50) NOT NULL,
  `admin` tinyint(4) NOT NULL DEFAULT '0',
  `sanktionspunkte` int(11) NOT NULL DEFAULT '0',
  `gestartet` int(11) NOT NULL DEFAULT '0',
  `team` int(11) NOT NULL,
  `cl` int(11) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Daten für Tabelle `User`
--

INSERT INTO `User` (`apikey`, `id`, `username`, `forumname`, `beitritt`, `telefon`, `rang`, `email`, `abteilung`, `aktiv`, `ausbilderBemerkung`, `personalBemerkung`, `uninvite`, `hwid`, `admin`, `sanktionspunkte`, `gestartet`, `team`, `cl`) VALUES
('1VUvBJJvoOcSLt10LKRV2qC0uydYwgjT', 84138, 'Nico_Karlson', 'Nico1310', '2019-01-30', 75230, 6, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('2ozM0XaWyBTB3BUNl9loXZIhUDDP3oxf', 82521, 'Arno_Shin', 'Y0nd0', '2019-01-30', 74627, 1, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('4GGWeLDfIsZJDYAQddQMAfJ4O7waiZyX', 44465, 'Daniel_Pinto', 'danielwornik', '2019-01-30', 39643, 1, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('6VqNLc1GgseJL37Z21aOovDc7kVl1bBP', 31508, 'Titus_Max', 'TitusMaximilian', '2019-01-30', 28502, 9, NULL, 2, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('7znpGkelb9kkxGL10TABqFdvUzkZFtbB', 62827, 'Mike_Mathews', 'Mike Mathews', '2018-01-26', 60253, 11, NULL, 3, 1, 'Ist sehr Faul im Programmieren', ' ', 0, '0fb98c9a-337a-4dec-8648-3646cd683a84', 1, 0, 0, 1, 2),
('80zMffSt1Qw84Xu9JTjg5T9iiikUQWZR', 78312, 'Stanley_Johnson', 'Stanley J.', '2019-01-30', 71738, 9, NULL, 2, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('9GdrMKgoaYsN0CwwVhqWXO34dlixcbaU', 71238, 'Andre_Maier', 'xodus787', '2019-01-30', 66235, 0, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('ACghH9TX0hPBd3Q7zPhWvQqUic0tEVV6', 46172, 'Zamo_Zamorra', 'IIZamoII', '2019-01-30', 41255, 8, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('ASDkm6BBsJSKLbBuIdujvvZ0YGIsyRgY', 75093, 'Boris_Slowkosvski', 'Heffa', '2019-01-30', 69178, 4, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('b6xQs9QYdwxoRDPh1V9yqE9ocraVFWWM', 42125, 'Alfons_Nightwalker', 'alme1611', '2019-01-30', 37770, 7, NULL, 4, 0, '', '', 0, 'd7e6c3be-bf70-4293-bb23-37ea847bac60', 0, 0, 0, 0, 2),
('ckJn1tGLTJ3KPFtz9fA4aMjdbRzxiTqL', 66742, 'Timon_Taylor', 'Timon_0586', '2019-01-30', 63130, 7, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('CTm89Yql88PW6Jn8Eoa125hzLjgvwmVR', 94746, 'Tyrone_Young', 'Mosakra', '2019-01-30', 77688, 1, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('cypMHbYZOEeOC6ZA71pz7yruX6t5bWnZ', 43436, 'Billy_Herrington', 'Billy Herrington', '2019-01-30', 38624, 4, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('db5awqXJuvPm3pKGO0HCVCAxEQFhbCpO', 56086, 'Marc_Ferus', 'Marc Ferus', '2019-01-30', 55328, 1, NULL, 0, 0, '', '', 0, 'e43fb591-4ba0-4ff2-81e5-2db145d471e2', 0, 0, 0, 0, 2),
('DfLB8BAg3TOMXGewwhXjasNxMcy4zV1Q', 17707, 'Thimo_Kuzneskow', 'Thimo_Kuzneskow', '2019-01-30', 16510, 2, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('DZkP7Jsnw4QXelYvBfefWsK3D1AjUex9', 89778, 'Andi_Klausen', 'TVkuhli', '2019-01-30', 76315, 0, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('e5PxaQEvN4BPTCW0WWZjWyOiIGPBk3Ql', 81546, 'Sirona_Calloway', 'Sirona_Calloway', '2019-01-30', 74112, 9, NULL, 2, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('fESf4QJMWvObimvfmbh5fiJ89Uq5COuT', 39082, 'Otis_Green', 'Psychobanane', '2019-01-30', 34751, 1, NULL, 0, 0, '', '', 0, '987052df-ed78-49a9-99ae-4024d9bc63e1', 0, 0, 0, 0, 0),
('GE6aMDGSKzKzDoNtmCR1NoTktwZiLON0', 41361, 'John_Targayen', 'Wade Winston Wilson', '2019-01-30', 36910, 1, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('HNXn6CPcaLiJROGXzNjQXzkgVh2ZGyP2', 79156, 'Paco_Aydin', 'Castieel', '2019-01-30', 72402, 0, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('iRL7UML6o1mlvIZbKJhrZ7gEGTE6lSsD', 38563, 'Max_Murdock', 'Max', '2019-01-18', 39838, 12, NULL, 0, 0, '', '', 2, '9b3df220-1093-4a5f-bf68-f82fb2d28b2c', 0, 0, 0, 0, 0),
('JvhWhfMO5wauPd3bKG3Dr1jf3BTDOXHD', 89227, 'Zoey_Night', 'Nightgirl', '2019-01-30', 76149, 1, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('LdcJlcKg3q5pduhmE7WgEcKwIwXcgo6o', 19920, 'Constant_Gardener', 'Constant Gardener', '2019-01-22', 18530, 9, NULL, 1, 0, '', '', 0, '69526b8e-6078-4d80-8347-1c68ac00d845', 0, 0, 0, 0, 0),
('lPUVNy01GkakTTFYjwodxyzeouzV6BvF', 29518, 'Paul_Kruse', 'Paul_Kruse', '2018-11-04', 27030, 10, NULL, 1, 1, '', ' ', 0, '20c30282-cf29-473e-a733-97ac25a30266', 0, 0, 0, 0, 2),
('M22ZBsp5ncYdamtHI2EDRR65P2uVmQvy', 79910, 'Martinez_Gonzalez', 'Martinez Gonzalez', '2019-01-30', 73009, 2, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('M9etjI6ZUe0Oc7V0p5ZZWRg2bZp7qzNy', 28108, 'Luca_Bernegger', 'Luca_Bernegger', '2017-09-01', 25824, 11, NULL, 2, 1, 'Ist 1 nicer Ausbilder', '', 0, 'f585ec73-93b0-40c2-b627-e68a4e4039c8', 0, 18, 1, 1, 2),
('mFNA9LUUKGQrKt7Vk62QmI9R4gk4oR6l', 40499, 'Erhart_Holz', 'Erhart Holz', '2019-02-02', 41774, 0, NULL, 0, 0, '', '', 2, '48653854-9034-4d71-8a82-c294bc918ebe', 1, 0, 0, 0, 0),
('MGFgXU3dalRBtBIfqbPKDGCIZIEPUJQr', 47255, 'Marvin_Radstake', 'Marvin_Radstake', '2019-01-30', 42418, 0, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('MWeiAxdfvVfsFULYAxebpdzF52YOVsSL', 16324, 'Andreas_Theke', 'Andreas_Theke', '2019-01-30', 43535, 8, NULL, 1, 0, '', '', 0, '5e2f65e8-b96f-40ca-8f4c-a4e23274275d', 0, 0, 0, 0, 2),
('mYdVGy2jLWQhj0oaud1LmqOPWiytTPWm', 48640, 'Jane_Hunter', 'Jane Hunter', '2019-01-30', 43274, 10, NULL, 2, 0, '', '', 0, '', 0, 0, 0, 1, 0),
('NZOyDmkIRuz0fgrrbqOcKi1TKhSqERfs', 23757, 'Diego_Corolla', 'AxoZz', '2019-01-30', 78046, 0, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('pOiIxbY6IfEX3ZbpvdrAgJVfyVvJS0d3', 22429, 'Rene_Aeon', 'Rene31Aeon', '2018-11-18', 20761, 12, NULL, 1, 0, '', ' ', 0, '043c4847-1e7a-47c5-bdcb-51bda327f290', 0, 0, 0, 0, 0),
('PxV3PnCyqQJVGLY6nxlpFuvR8C3zSfeH', 67475, 'Logomon_Calle', 'Logomon_calle', '2019-01-30', 63632, 9, NULL, 4, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('RacbtYcxU8VHdwYTvvhPp1rFaBHnW6E0', 22808, 'Rosa_Meinecke', 'Rosaa', '2019-01-30', 73441, 2, NULL, 4, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('RiDCT7yBPY5jzM54CXfyUdsqqEzSSQuu', 15947, 'Tim_Taylor', 'xxTimMGxx', '2017-08-06', 18895, 9, NULL, 3, 1, 'Mikes', ' ', 0, '', 0, 0, 0, 0, 0),
('srxt6wFzJurrUUtsbbh1Qp1MKpZ73eDj', 72901, 'John_Bradford', 'John Bradford', '2019-01-18', 67262, 10, NULL, 3, 0, '', '', 0, 'a00eead7-6e8b-49a9-9424-6c50cc7ae73f', 0, 0, 0, 0, 2),
('SxSTyJqpbw23UomE5N0bpm8tbEtyfTii', 70185, 'Nick_Pilton', 'Nick Pilton', '2019-01-30', 65632, 0, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('TChvhdH3RN8U3asMY7zSb8L2u6QnWgN7', 73760, 'OnkelRocky_Wacholsky', 'OnkelRocky Wacholsky', '2019-01-30', 68034, 2, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('tj3FrZhgfMm9DqOgbf14N3cZVEmyv1PX', 64864, 'Paul_Kalim', 'EliteGamer92', '2019-01-30', 61735, 2, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('TX7GjaAPBe9cOScwoJhnhcGELBugiBm0', 81042, 'Marc_Robins', 'Marc_Robins', '2019-01-30', 73784, 1, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('uGAJmegT24ESSgCInVHzmNWCRM7ZXP9t', 44210, 'Synex_Samas', 'Synex', '2019-01-30', 39383, 1, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('urIjS2DLJhCRtUy5F38FJY9HkARfmHUq', 59261, 'Arthur_Kuzneskow', 'Arthur Kuzneskow', '2019-01-30', 59270, 3, NULL, 3, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('vAarsfIIfOhmFdtq6FXePMUhqHU8AXZr', 23297, 'Evelyn_Hall', 'Evelyn Hall', '2019-01-30', 21591, 10, NULL, 1, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('VSQL2iq2pOOcFJzI4fHs6ZIwkbchoQ2Q', 27892, 'Davvad_Freitag', 'Davvad_Freitag', '2018-11-06', 25642, 12, NULL, 0, 1, 'Testweise', ' ', 0, '8687ba56-bff3-4ee4-a38f-f2ee22dfcbbd', 0, 13, 0, 1, 2),
('WBqNC0aFdtQbCbezmIjoJCfOt9ZPmIox', 27058, 'Justin_Schweitzer', 'Justin Schweitzer', '2019-01-30', 24925, 2, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('xl3aJWEKDMiIdY6oXFXOhde5CnmligJZ', 92485, 'Kerry_Night', 'kerry night', '2019-01-30', 77093, 3, NULL, 0, 0, '', '', 0, '72f742aa-af05-464a-bed7-b7f028630487', 0, 0, 0, 0, 2),
('Xw5JtuhUYIbm712wbysFjvtXXiypYbbH', 69774, 'Harry_Mondego', 'Harry Mondego', '2019-01-30', 65335, 8, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('y2aShvHGrXdqqFV3h44N1nXEgO30wnfz', 34756, 'Gunther_Mueller', 'TrickzZ', '2019-01-30', 31134, 0, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('Y58qdG5mkieoTTIcm2zfUDjvOL0H4BBz', 75306, 'Barrie_Rammler', 'Rammler', '2019-01-30', 76581, 6, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('yCIiC5fJ5tBFVgmSB4ek9LEUvQWoTEHt', 76449, 'Isabell_Walker', 'Isabell Walker', '2019-01-30', 70220, 0, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0),
('YUXLmFlr28yFcyi3bMNJ3vxCeUkR6J3w', 62618, 'Felix_Verdame', 'Kaniggel', '2019-02-10', 60099, 0, NULL, 0, 0, '', '', 0, 'e8232791-791a-46c5-86a7-2305fcfd1029', 0, 0, 0, 0, 2),
('zGdBIi5y5xmGr4Hxb2szZS19dRlekgNf', 74309, 'Robin_Walter', 'Robin Walter', '2019-01-30', 68500, 1, NULL, 0, 0, '', '', 0, '', 0, 0, 0, 0, 0);

--
-- Indizes der exportierten Tabellen
--

--
-- Indizes für die Tabelle `Archiv`
--
ALTER TABLE `Archiv`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `AusbildungsTermine`
--
ALTER TABLE `AusbildungsTermine`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Beladung`
--
ALTER TABLE `Beladung`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `BewerbungFallbeispiele`
--
ALTER TABLE `BewerbungFallbeispiele`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Bewerbungstermine`
--
ALTER TABLE `Bewerbungstermine`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Changelog`
--
ALTER TABLE `Changelog`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Dienstzeit`
--
ALTER TABLE `Dienstzeit`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `FahrzeugbeladungArchiv`
--
ALTER TABLE `FahrzeugbeladungArchiv`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Fahrzeuge`
--
ALTER TABLE `Fahrzeuge`
  ADD PRIMARY KEY (`nummer`);

--
-- Indizes für die Tabelle `Fahrzeug_Einsatz`
--
ALTER TABLE `Fahrzeug_Einsatz`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Freistellung`
--
ALTER TABLE `Freistellung`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `FST`
--
ALTER TABLE `FST`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `FSTListe`
--
ALTER TABLE `FSTListe`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `mdw`
--
ALTER TABLE `mdw`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Patientenliste`
--
ALTER TABLE `Patientenliste`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Pruefungen`
--
ALTER TABLE `Pruefungen`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Pruefungsliste`
--
ALTER TABLE `Pruefungsliste`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `rankupBedinungen`
--
ALTER TABLE `rankupBedinungen`
  ADD PRIMARY KEY (`rang`);

--
-- Indizes für die Tabelle `Sanktionen`
--
ALTER TABLE `Sanktionen`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Schulungen`
--
ALTER TABLE `Schulungen`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Schulungsliste`
--
ALTER TABLE `Schulungsliste`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Schwarzes_Brett`
--
ALTER TABLE `Schwarzes_Brett`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Strafkatalog`
--
ALTER TABLE `Strafkatalog`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `updownrank`
--
ALTER TABLE `updownrank`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `Urlaub`
--
ALTER TABLE `Urlaub`
  ADD PRIMARY KEY (`id`);

--
-- Indizes für die Tabelle `User`
--
ALTER TABLE `User`
  ADD PRIMARY KEY (`apikey`,`id`);

--
-- AUTO_INCREMENT für exportierte Tabellen
--

--
-- AUTO_INCREMENT für Tabelle `Archiv`
--
ALTER TABLE `Archiv`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT für Tabelle `AusbildungsTermine`
--
ALTER TABLE `AusbildungsTermine`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;
--
-- AUTO_INCREMENT für Tabelle `Beladung`
--
ALTER TABLE `Beladung`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT für Tabelle `BewerbungFallbeispiele`
--
ALTER TABLE `BewerbungFallbeispiele`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT für Tabelle `Bewerbungstermine`
--
ALTER TABLE `Bewerbungstermine`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- AUTO_INCREMENT für Tabelle `Changelog`
--
ALTER TABLE `Changelog`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT für Tabelle `Dienstzeit`
--
ALTER TABLE `Dienstzeit`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=56;
--
-- AUTO_INCREMENT für Tabelle `FahrzeugbeladungArchiv`
--
ALTER TABLE `FahrzeugbeladungArchiv`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT für Tabelle `Fahrzeug_Einsatz`
--
ALTER TABLE `Fahrzeug_Einsatz`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `Freistellung`
--
ALTER TABLE `Freistellung`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT für Tabelle `FST`
--
ALTER TABLE `FST`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT für Tabelle `FSTListe`
--
ALTER TABLE `FSTListe`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT für Tabelle `mdw`
--
ALTER TABLE `mdw`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT für Tabelle `Patientenliste`
--
ALTER TABLE `Patientenliste`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT für Tabelle `Pruefungen`
--
ALTER TABLE `Pruefungen`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT für Tabelle `Pruefungsliste`
--
ALTER TABLE `Pruefungsliste`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT für Tabelle `Sanktionen`
--
ALTER TABLE `Sanktionen`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- AUTO_INCREMENT für Tabelle `Schulungen`
--
ALTER TABLE `Schulungen`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT für Tabelle `Schulungsliste`
--
ALTER TABLE `Schulungsliste`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT für Tabelle `Schwarzes_Brett`
--
ALTER TABLE `Schwarzes_Brett`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT für Tabelle `Strafkatalog`
--
ALTER TABLE `Strafkatalog`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT für Tabelle `updownrank`
--
ALTER TABLE `updownrank`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT für Tabelle `Urlaub`
--
ALTER TABLE `Urlaub`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

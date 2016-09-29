USE LibraryDemo;

CREATE TABLE IF NOT EXISTS `Book` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Author` varchar(255) NOT NULL,
  `PublishDate` datetime NOT NULL,
  `Title` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
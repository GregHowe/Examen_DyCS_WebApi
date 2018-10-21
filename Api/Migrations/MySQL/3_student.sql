CREATE TABLE student (
  student_id bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  nombre VARCHAR(100) NOT NULL,
  apellido VARCHAR(100) NOT NULL,
  pais VARCHAR(100) NOT NULL,
 edad INT NOT NULL,
 username VARCHAR(100) NOT NULL,
 password VARCHAR(100) NOT NULL,
  PRIMARY KEY (student_id),
  UNIQUE KEY student_id_UNIQUE (student_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO student (nombre, apellido, pais, edad, username, password) values ('Omar', 'Fernandez', 'PERU' , 27 , 'omarfc83', 'jumpstart');
INSERT INTO student (nombre, apellido, pais, edad, username, password) values ('Francisco', 'Peralta', 'ECUADOR' , 35 , 'Francis35', 'manhattan');
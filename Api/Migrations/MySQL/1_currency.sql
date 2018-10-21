CREATE TABLE currency (
  currency_id bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  iso_code varchar(3) NOT NULL,
  PRIMARY KEY (currency_id),
  UNIQUE KEY currency_id_UNIQUE (currency_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT INTO currency(currency_id,iso_code) VALUES(604,'PEN');
INSERT INTO currency(currency_id,iso_code) VALUES(840,'USD');
INSERT INTO currency(currency_id,iso_code) VALUES(978,'EUR');
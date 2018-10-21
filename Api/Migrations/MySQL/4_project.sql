CREATE TABLE project (
  project_id bigint UNSIGNED NOT NULL AUTO_INCREMENT,
  project_name varchar(200) NOT NULL,
  budget decimal(10,2) DEFAULT NULL,
  currency_id bigint UNSIGNED NOT NULL,
  student_id bigint UNSIGNED NOT NULL,
  number_days_project bigint UNSIGNED NOT NULL,
  PRIMARY KEY (project_id),
  UNIQUE KEY project_id_UNIQUE (project_id),
  CONSTRAINT FK_project_student_id FOREIGN KEY(student_id) REFERENCES student(student_id),
  CONSTRAINT FK_project_currency_id FOREIGN KEY(currency_id) REFERENCES currency(currency_id)
) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

INSERT into project (project_name,budget,currency_id,student_id, number_days_project) values ('TransMobile',1000000.00,604,1, 15);
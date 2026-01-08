CREATE DATABASE task_manager;
USE task_manager;

CREATE TABLE tasks(
	id INT auto_increment PRIMARY KEY,
    title VARCHAR(255) NOT NULL,
    description VARCHAR(255),
    is_completed BOOLEAN NOT NULL,
    created_at DATETIME NOT NULL
);
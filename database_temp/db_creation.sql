-- Create the onlineexaminationsystem database
CREATE DATABASE IF NOT EXISTS onlineexaminationsystem;

-- Use the onlineexaminationsystem database
USE onlineexaminationsystem;

-- Student Table
CREATE TABLE student (
    roll_number INT PRIMARY KEY,
    name VARCHAR(255),
    email VARCHAR(255),
    password VARCHAR(255)
);

-- Insert data into the student table
-- INSERT INTO student (roll_number, name, email, password) VALUES
-- (1, 'John Doe', 'john@example.com', 'password123'),
-- (2, 'Jane Smith', 'jane@example.com', 'pass456'),
-- (3, 'Alice Johnson', 'alice@example.com', 'qwerty');

-- Section Table
CREATE TABLE section (
    section_id INT PRIMARY KEY,
    section_name VARCHAR(255),
    no_of_qs INT,
    marks INT
);

-- Insert data into the section table
-- INSERT INTO section (section_id, section_name, no_of_qs, marks) VALUES
-- (1, 'Mathematics', 2, 10),
-- (2, 'Literature', 1, 5);

-- Question Pool Table
CREATE TABLE question_pool (
    question_id INT PRIMARY KEY,
    section_id INT,
    question VARCHAR(255),
    answer VARCHAR(255),
    option1 VARCHAR(255),
    option2 VARCHAR(255),
    option3 VARCHAR(255),
    option4 VARCHAR(255),
    FOREIGN KEY (section_id) REFERENCES section(section_id)
);

-- Insert data into the question_pool table
-- INSERT INTO question_pool (question_id, section_id, question, answer, option1, option2, option3, option4) VALUES
-- (1, 1, 'What is 2+2?', '4', '3', '4', '5', '6'),
-- (2, 1, 'What is the capital of France?', 'Paris', 'London', 'Berlin', 'Madrid', 'Paris'),
-- (3, 2, 'Who wrote "Romeo and Juliet"?', 'William Shakespeare', 'Charles Dickens', 'Jane Austen', 'William Shakespeare', 'Ernest Hemingway');

-- Admin Table
CREATE TABLE admin (
    admin_id INT PRIMARY KEY,
    email_id VARCHAR(255),
    password VARCHAR(255),
    sections INT,
    entered BOOLEAN default 0,
    FOREIGN KEY (sections) REFERENCES section(section_id)
);

-- Insert data into the admin table
-- INSERT INTO admin (admin_id, email_id, password, sections) VALUES
-- (1, 'admin@example.com', 'adminpass', 1);

-- Student Answers Table
CREATE TABLE student_answers (
    roll_number INT,
    question_id INT,
    selected_answer VARCHAR(255),
    FOREIGN KEY (roll_number) REFERENCES student(roll_number),
    FOREIGN KEY (question_id) REFERENCES question_pool(question_id)
);

-- Insert data into the student_answers table
-- INSERT INTO student_answers (roll_number, question_id, selected_answer) VALUES
-- (1, 1, '4'),
-- (1, 2, 'Paris'),
-- (2, 1, '4'),
-- (3, 3, 'William Shakespeare');

-- Results Table
CREATE TABLE results (
    roll_number INT,
    marks INT,
    FOREIGN KEY (roll_number) REFERENCES student(roll_number)
);

-- Insert data into the results table
-- INSERT INTO results (roll_number, marks) VALUES
-- (1, 15),
-- (2, 10),
-- (3, 5);

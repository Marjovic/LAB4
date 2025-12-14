DROP DATABASE IF EXISTS DB_ALEJADO;
CREATE DATABASE DB_ALEJADO;
USE DB_ALEJADO;


-- Roles table
CREATE TABLE Roles (
    role_id INT PRIMARY KEY AUTO_INCREMENT,
    role_name VARCHAR(50) UNIQUE NOT NULL,
    description VARCHAR(255),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Roles (role_name, description) VALUES 
    ('Admin', 'System administrator with full access'),
    ('Teacher', 'Instructor who teaches courses'),
    ('Student', 'Enrolled student');

-- Phone_Types table
CREATE TABLE Phone_Types (
    phone_type_id INT PRIMARY KEY AUTO_INCREMENT,
    type_name VARCHAR(20) UNIQUE NOT NULL,
    description VARCHAR(100),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Phone_Types (type_name, description) VALUES 
    ('Mobile', 'Primary mobile phone number'),
    ('Home', 'Home landline number'),
    ('Work', 'Work/office phone number'),
    ('Emergency', 'Emergency contact number');

-- Semester_Types table
CREATE TABLE Semester_Types (
    semester_type_id INT PRIMARY KEY AUTO_INCREMENT,
    type_name VARCHAR(50) UNIQUE NOT NULL,
    type_code VARCHAR(10) UNIQUE NOT NULL,
    display_order INT UNIQUE NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Semester_Types (type_name, type_code, display_order) VALUES 
    ('First Semester', '1ST', 1),
    ('Second Semester', '2ND', 2),
    ('Summer', 'SUM', 3);

-- Enrollment_Status_Types table
CREATE TABLE Enrollment_Status_Types (
    status_id INT PRIMARY KEY AUTO_INCREMENT,
    status_name VARCHAR(50) UNIQUE NOT NULL,
    status_description VARCHAR(255),
    is_active_status BOOLEAN DEFAULT TRUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Enrollment_Status_Types (status_name, status_description, is_active_status) VALUES 
    ('Enrolled', 'Currently enrolled in the course', TRUE),
    ('Completed', 'Successfully completed the course', FALSE),
    ('Failed', 'Did not pass the course', FALSE),
    ('Dropped', 'Dropped the course during add/drop period', FALSE),
    ('Withdrawn', 'Withdrew from course after add/drop period', FALSE),
    ('Incomplete', 'Received incomplete grade', TRUE);

-- Year_Levels table
CREATE TABLE Year_Levels (
    year_level_id INT PRIMARY KEY AUTO_INCREMENT,
    year_number INT UNIQUE NOT NULL,
    year_level_name VARCHAR(50) GENERATED ALWAYS AS (
        CASE
            WHEN year_number = 1 THEN '1st Year'
            WHEN year_number = 2 THEN '2nd Year'
            WHEN year_number = 3 THEN '3rd Year'
            ELSE CONCAT(year_number, 'th Year')
        END
    ) VIRTUAL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Year_Levels (year_number) VALUES (1),(2),(3),(4);

-- Subject_Categories table (for curriculum classification)
CREATE TABLE Subject_Categories (
    category_id INT PRIMARY KEY AUTO_INCREMENT,
    category_name VARCHAR(50) UNIQUE NOT NULL,
    category_code VARCHAR(10) UNIQUE NOT NULL,
    description VARCHAR(255),
    display_order INT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Subject_Categories (category_name, category_code, description, display_order) VALUES
    ('Major', 'MAJ', 'Core major subjects specific to the program', 1),
    ('Minor', 'MIN', 'Secondary specialization subjects', 2),
    ('General Education', 'GE', 'General education subjects required for all programs', 3);

-- AssignmentTypes table
CREATE TABLE AssignmentTypes (
    type_id INT PRIMARY KEY AUTO_INCREMENT,
    type_name VARCHAR(100) UNIQUE NOT NULL,
    type_code VARCHAR(20) UNIQUE NOT NULL,
    default_weight DECIMAL(5,2) NOT NULL,
    description VARCHAR(255),
    is_active BOOLEAN DEFAULT TRUE,
    display_order INT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    CONSTRAINT chk_weight_range CHECK (default_weight >= 0 AND default_weight <= 100),
    INDEX idx_active (is_active),
    INDEX idx_display_order (display_order)
);

INSERT INTO AssignmentTypes (type_name, type_code, default_weight, description, display_order) VALUES 
    ('Quiz',         'QZ',    16.67, 'Short quizzes and knowledge checks', 1),
    ('Assignments',  'ASG',   15.00, 'Homework and other assignments',     2),
    ('Participation','PART',  10.00, 'Class participation and attendance', 3),
    ('Exam',         'EXAM',  33.33, 'Major written/oral examinations',    4),
    ('Laboratories', 'LAB',   25.00, 'Laboratory exercises and reports',   5);

-- Grading_Periods table (Prelim/Midterm/Finals)
CREATE TABLE Grading_Periods (
    period_id INT PRIMARY KEY AUTO_INCREMENT,
    period_name VARCHAR(50) UNIQUE NOT NULL,
    period_code VARCHAR(10) UNIQUE NOT NULL,
    period_weight DECIMAL(5,2) NOT NULL,
    display_order INT UNIQUE NOT NULL,
    description VARCHAR(255),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT chk_period_weight CHECK (period_weight >= 0 AND period_weight <= 100),
    INDEX idx_display_order (display_order)
);

INSERT INTO Grading_Periods (period_name, period_code, period_weight, display_order, description) VALUES 
    ('Prelim',  'PREL', 33.33, 1, 'Preliminary examination period'),
    ('Midterm', 'MID',  33.33, 2, 'Midterm examination period'),
    ('Finals',  'FIN',  33.34, 3, 'Final examination period');

-- Days_Of_Week table (for schedule normalization)
CREATE TABLE Days_Of_Week (
    day_id INT PRIMARY KEY AUTO_INCREMENT,
    day_name VARCHAR(10) UNIQUE NOT NULL,
    day_code VARCHAR(3) UNIQUE NOT NULL,
    display_order INT UNIQUE NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Days_Of_Week (day_name, day_code, display_order) VALUES
    ('Monday', 'MON', 1),
    ('Tuesday', 'TUE', 2),
    ('Wednesday', 'WED', 3),
    ('Thursday', 'THU', 4),
    ('Friday', 'FRI', 5),
    ('Saturday', 'SAT', 6),
    ('Sunday', 'SUN', 7);

-- USER MANAGEMENT
CREATE TABLE Users (
    user_id INT PRIMARY KEY AUTO_INCREMENT,
    username VARCHAR(255) UNIQUE NOT NULL,
    password_hash VARCHAR(255) NOT NULL,
    role_id INT NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    last_login DATETIME,
    is_active BOOLEAN DEFAULT TRUE,
    FOREIGN KEY (role_id) REFERENCES Roles(role_id),
    INDEX idx_username (username),
    INDEX idx_active (is_active),
    INDEX idx_role (role_id)
);

INSERT INTO Users (username, password_hash, role_id, is_active)
VALUES 
    ('marjovic', SHA2('marjovic123', 256), 1, TRUE), 
    ('teacher1', SHA2('teacher123', 256), 2, TRUE),
    ('teacher2', SHA2('teacher123', 256), 2, TRUE),
    ('student1', SHA2('student123', 256), 3, TRUE),
    ('student2', SHA2('student123', 256), 3, TRUE);


-- Rooms table (for schedule normalization)
CREATE TABLE Rooms (
    room_id INT PRIMARY KEY AUTO_INCREMENT,
    room_code VARCHAR(20) UNIQUE NOT NULL,
    room_name VARCHAR(100),
    building VARCHAR(100),
    capacity INT DEFAULT 40,
    room_type ENUM('Lecture', 'Laboratory', 'Online') DEFAULT 'Lecture',
    is_active BOOLEAN DEFAULT TRUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_room_code (room_code),
    INDEX idx_building (building),
    INDEX idx_room_type (room_type),
    INDEX idx_active (is_active)
);

INSERT INTO Rooms (room_code, room_name, building, capacity, room_type) VALUES
    ('CIT-101', 'IT Lecture Room 1', 'EMM201', 45, 'Lecture'),
    ('CIT-102', 'IT Lecture Room 2', 'EMM303', 45, 'Lecture'),
    ('CIT-LAB1', 'Computer Laboratory 1', 'COM-A', 40, 'Laboratory'),
    ('CIT-LAB2', 'Computer Laboratory 2', 'COM-B', 40, 'Laboratory'),
    ('CBA-101', 'Business Lecture Room 1', 'FGM-301', 50, 'Lecture'),
    ('ONLINE', 'Virtual Classroom', NULL, 999, 'Online');

-- Departments table
CREATE TABLE Departments (
    department_id INT PRIMARY KEY AUTO_INCREMENT,
    department_name VARCHAR(100) UNIQUE NOT NULL,
    department_code VARCHAR(20) UNIQUE NOT NULL,
    description TEXT,
    head_instructor_id INT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    INDEX idx_code (department_code)
);

INSERT INTO Departments (department_name, department_code, description) VALUES
    ('College of Engineering and Technology', 'CET', 'Department for Engineering, IT and Computer Science programs'),
    ('College of Business Education', 'CBA', 'Department for Business and Management programs'),
    ('College of Arts and Sciences', 'CAS', 'Department for Liberal Arts and Sciences programs');

-- ACADEMIC CALENDAR
CREATE TABLE Academic_Years (
    academic_year_id INT PRIMARY KEY AUTO_INCREMENT,
    year_start INT NOT NULL,
    year_end INT NOT NULL,
    academic_year_name VARCHAR(20) GENERATED ALWAYS AS (CONCAT(year_start, '-', year_end)) VIRTUAL,
    is_current BOOLEAN DEFAULT FALSE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT unique_academic_year UNIQUE (year_start, year_end),
    CONSTRAINT check_year_sequence CHECK (year_end = year_start + 1),
    INDEX idx_current (is_current)
);

INSERT INTO Academic_Years (year_start, year_end, is_current) VALUES
    (2025, 2026, TRUE),   
    (2026, 2027, FALSE),
    (2027, 2028, FALSE),
    (2028, 2029, FALSE),
    (2029, 2030, FALSE);

CREATE TABLE Semesters (
    semester_id INT PRIMARY KEY AUTO_INCREMENT,
    academic_year_id INT NOT NULL,
    semester_type_id INT NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    is_active BOOLEAN DEFAULT FALSE,
    registration_start_date DATE,
    registration_end_date DATE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (academic_year_id) REFERENCES Academic_Years(academic_year_id),
    FOREIGN KEY (semester_type_id) REFERENCES Semester_Types(semester_type_id),
    CONSTRAINT unique_semester UNIQUE (academic_year_id, semester_type_id),
    CONSTRAINT check_dates CHECK (end_date > start_date),
    CONSTRAINT check_registration CHECK (registration_end_date >= registration_start_date),
    INDEX idx_active (is_active)
);

INSERT INTO Semesters (academic_year_id, semester_type_id, start_date, end_date, is_active, registration_start_date, registration_end_date) VALUES
    (1, 1, '2025-08-15', '2025-12-20', TRUE, '2025-07-01', '2025-08-10'),
    (1, 2, '2026-01-10', '2026-05-25', FALSE, '2025-12-01', '2026-01-05'),
    (2, 1, '2026-08-15', '2026-12-20', FALSE, '2026-07-01', '2026-08-10');

CREATE TABLE Term_Types (
    term_type_id INT PRIMARY KEY AUTO_INCREMENT,
    type_name VARCHAR(50) UNIQUE NOT NULL,
    type_code VARCHAR(10) UNIQUE NOT NULL,
    duration_description VARCHAR(100),
    display_order INT UNIQUE NOT NULL,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Term_Types (type_name, type_code, duration_description, display_order) VALUES 
    ('Term 1', 'T1', 'First Half Semester', 1),
    ('Term 2', 'T2', 'Second Half Semester', 2),
    ('Term 3', 'T3', 'Whole Semester', 3);

CREATE TABLE Terms (
    term_id INT PRIMARY KEY AUTO_INCREMENT,
    semester_id INT NOT NULL,
    term_type_id INT NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    is_active BOOLEAN DEFAULT FALSE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (semester_id) REFERENCES Semesters(semester_id) ON DELETE CASCADE,
    FOREIGN KEY (term_type_id) REFERENCES Term_Types(term_type_id),
    CONSTRAINT unique_semester_term UNIQUE (semester_id, term_type_id),
    CONSTRAINT check_term_dates CHECK (end_date > start_date),
    INDEX idx_semester (semester_id),
    INDEX idx_term_type (term_type_id),
    INDEX idx_active (is_active),
    INDEX idx_dates (start_date, end_date)
);
INSERT INTO Terms (semester_id, term_type_id, start_date, end_date, is_active) VALUES
    (1, 1, '2025-08-15', '2025-10-15', TRUE),
    (1, 2, '2025-10-16', '2025-12-20', FALSE),
    (2, 1, '2026-01-10', '2026-03-10', FALSE);

CREATE TABLE Term_Grading_Periods (
    term_period_id INT PRIMARY KEY AUTO_INCREMENT,
    term_id INT NOT NULL,
    period_id INT NOT NULL,
    start_date DATE NOT NULL,
    end_date DATE NOT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (term_id) REFERENCES Terms(term_id) ON DELETE CASCADE,
    FOREIGN KEY (period_id) REFERENCES Grading_Periods(period_id),
    CONSTRAINT unique_term_period UNIQUE (term_id, period_id),
    CONSTRAINT check_period_dates CHECK (end_date > start_date),
    INDEX idx_term (term_id),
    INDEX idx_period (period_id),
    INDEX idx_dates (start_date, end_date)
);

INSERT INTO Term_Grading_Periods (term_id, period_id, start_date, end_date, is_active) VALUES
    (1, 1, '2025-08-15', '2025-09-15', TRUE),
    (1, 2, '2025-09-16', '2025-10-10', FALSE),
    (1, 3, '2025-10-11', '2025-10-15', FALSE);


-- PROGRAMS AND CURRICULUM
CREATE TABLE Programs (
    program_id INT PRIMARY KEY AUTO_INCREMENT,
    program_code VARCHAR(20) UNIQUE NOT NULL,
    program_name VARCHAR(255) NOT NULL,
    program_description TEXT,
    department_id INT,
    total_units_required INT DEFAULT 160,
    years_to_complete INT DEFAULT 4,
    is_active BOOLEAN DEFAULT TRUE,
    accreditation_status VARCHAR(100),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES Departments(department_id) ON DELETE SET NULL,
    INDEX idx_program_code (program_code),
    INDEX idx_department (department_id),
    INDEX idx_active (is_active)
);

INSERT INTO Programs (program_code, program_name, program_description, department_id, total_units_required, years_to_complete, accreditation_status) VALUES
    ('BSIT', 'Bachelor of Science in Information Technology', 'Program focused on IT infrastructure, web development, and system administration', 1, 160, 4, 'CHED Recognized - Level III'),
    ('BSCS', 'Bachelor of Science in Computer Science', 'Program focused on algorithms, software engineering, and theoretical computing', 1, 165, 4, 'CHED Recognized - Level III');


-- INSTRUCTORS AND STUDENTS
CREATE TABLE Instructors (
    instructor_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT UNIQUE NOT NULL,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    middle_name VARCHAR(100),
    department_id INT,
    email VARCHAR(255) UNIQUE,
    hire_date DATE,
    employment_status ENUM('Active', 'On Leave', 'Retired', 'Terminated') DEFAULT 'Active',
    specialization VARCHAR(255),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (department_id) REFERENCES Departments(department_id),
    INDEX idx_last_name (last_name),
    INDEX idx_email (email),
    INDEX idx_department (department_id),
    INDEX idx_employment_status (employment_status)
);

INSERT INTO Instructors (user_id, first_name, last_name, middle_name, department_id, email, hire_date, employment_status, specialization) VALUES
    (2, 'Victor', 'Alejado', 'Tabaniera', 1, 'victoralejado@gmail.com', '2020-08-15', 'Active', 'Database Systems & Web Development'),
    (3, 'Virginia', 'Alejado', 'Prato', 1, 'virginiaalejado@gmail.com', '2019-06-01', 'Active', 'Software Engineering & Algorithms');

CREATE TABLE Students (
    student_id INT PRIMARY KEY AUTO_INCREMENT,
    user_id INT UNIQUE NOT NULL,
    student_number VARCHAR(50) UNIQUE NOT NULL,
    first_name VARCHAR(100) NOT NULL,
    last_name VARCHAR(100) NOT NULL,
    middle_name VARCHAR(100),
    date_of_birth DATE,
    year_level_id INT,
    department_id INT,
    program_id INT,
    email VARCHAR(255) UNIQUE,
    enrollment_year INT NULL,
    current_status_id INT NULL,
    admission_date DATE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (user_id) REFERENCES Users(user_id) ON DELETE CASCADE,
    FOREIGN KEY (year_level_id) REFERENCES Year_Levels(year_level_id),
    FOREIGN KEY (department_id) REFERENCES Departments(department_id),
    FOREIGN KEY (program_id) REFERENCES Programs(program_id),
    FOREIGN KEY (current_status_id) REFERENCES Enrollment_Status_Types(status_id),
    INDEX idx_student_number (student_number),
    INDEX idx_last_name (last_name),
    INDEX idx_email (email),
    INDEX idx_current_status (current_status_id),
    INDEX idx_year_level (year_level_id),
    INDEX idx_department (department_id),
    INDEX idx_program (program_id)
);

INSERT INTO Students (user_id, student_number, first_name, last_name, middle_name, date_of_birth, year_level_id, department_id, program_id, email, enrollment_year, current_status_id, admission_date) VALUES
    (4, '2025-00001', 'Vivir Lei', 'Alejado', 'Prato', '2005-03-15', 1, 1, 1, 'vivirleialejado@gmail.com', 2025, 1, '2025-08-01'),
    (5, '2025-00002', 'Mary Joy', 'Alejado', 'Prato', '2005-07-22', 1, 1, 2, 'maryjoyalejado@gmail.com', 2025, 1, '2025-08-01');

ALTER TABLE Departments 
ADD CONSTRAINT fk_dept_head 
FOREIGN KEY (head_instructor_id) REFERENCES Instructors(instructor_id) ON DELETE SET NULL;

CREATE TABLE Student_Phones (
    phone_id INT PRIMARY KEY AUTO_INCREMENT,
    student_id INT NOT NULL,
    phone_number VARCHAR(20) NOT NULL,
    phone_type_id INT NOT NULL,
    is_primary BOOLEAN DEFAULT FALSE,
    notes VARCHAR(255),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE,
    FOREIGN KEY (phone_type_id) REFERENCES Phone_Types(phone_type_id),
    CONSTRAINT unique_student_phone UNIQUE (student_id, phone_number),
    INDEX idx_student (student_id),
    INDEX idx_phone_type (phone_type_id),
    INDEX idx_primary (student_id, is_primary)
);
INSERT INTO Student_Phones (student_id, phone_number, phone_type_id, is_primary, notes) VALUES
    (1, '+63-917-1234567', 1, TRUE, 'Personal mobile'),
    (2, '+63-918-7654321', 1, TRUE, 'Personal mobile');

-- COURSE/SUBJECT MANAGEMENT
CREATE TABLE Courses (
    course_id INT PRIMARY KEY AUTO_INCREMENT,
    course_code VARCHAR(50) UNIQUE NOT NULL,
    course_name VARCHAR(255) NOT NULL,
    course_description TEXT,
    lab_units INT DEFAULT 0,
    lecture_units INT DEFAULT 3,
    credits INT GENERATED ALWAYS AS (lab_units + lecture_units) VIRTUAL,
    department_id INT NULL,
    is_active BOOLEAN DEFAULT TRUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (department_id) REFERENCES Departments(department_id),
    INDEX idx_course_code (course_code),
    INDEX idx_courses_search (course_code, course_name),
    INDEX idx_department (department_id),
    INDEX idx_active (is_active)
);

-- IT Courses
INSERT INTO Courses (course_code, course_name, course_description, lab_units, lecture_units, department_id, is_active) VALUES
    ('IT-111', 'Introduction to Computing', 'Fundamentals of computing and problem solving', 1, 2, 1, TRUE),
    ('IT-112', 'Computer Programming 1', 'Introduction to programming fundamentals', 1, 2, 1, TRUE),
    ('IT-121', 'Computer Programming 2', 'Object-oriented programming concepts', 1, 2, 1, TRUE),
    ('IT-211', 'Data Structures and Algorithms', 'Study of fundamental data structures', 1, 2, 1, TRUE),
    ('IT-212', 'Database Management Systems', 'Design and implementation of databases', 1, 2, 1, TRUE),
    ('IT-221', 'Web Development', 'Frontend and backend web technologies', 1, 2, 1, TRUE),
    ('IT-311', 'System Administration', 'Server and network administration', 1, 2, 1, TRUE),
    ('IT-312', 'Network Security', 'Security principles and practices', 1, 2, 1, TRUE),
    ('IT-411', 'Capstone Project 1', 'First part of capstone project', 0, 3, 1, TRUE),
    ('IT-412', 'Capstone Project 2', 'Final capstone project completion', 0, 3, 1, TRUE);

-- CS Courses
INSERT INTO Courses (course_code, course_name, course_description, lab_units, lecture_units, department_id, is_active) VALUES
    ('CS-111', 'Discrete Mathematics', 'Mathematical foundations for CS', 0, 3, 1, TRUE),
    ('CS-211', 'Advanced Data Structures', 'Complex data structures and algorithms', 1, 2, 1, TRUE),
    ('CS-212', 'Software Engineering', 'Software development methodologies', 1, 2, 1, TRUE),
    ('CS-311', 'Theory of Computation', 'Automata and formal languages', 0, 3, 1, TRUE),
    ('CS-312', 'Artificial Intelligence', 'AI principles and applications', 1, 2, 1, TRUE),
    ('CS-321', 'Operating Systems', 'OS design and implementation', 1, 2, 1, TRUE),
    ('CS-411', 'Compiler Design', 'Compiler construction principles', 1, 2, 1, TRUE),
    ('CS-412', 'Thesis 1', 'Research and thesis writing part 1', 0, 3, 1, TRUE),
    ('CS-421', 'Thesis 2', 'Research and thesis writing part 2', 0, 3, 1, TRUE);

-- General Education Courses
INSERT INTO Courses (course_code, course_name, course_description, lab_units, lecture_units, department_id, is_active) VALUES
    ('GE-101', 'Understanding the Self', 'Personal development and psychology', 0, 3, 3, TRUE),
    ('GE-102', 'Readings in Philippine History', 'Philippine historical development', 0, 3, 3, TRUE),
    ('GE-103', 'Mathematics in the Modern World', 'Mathematical reasoning and applications', 0, 3, 3, TRUE),
    ('GE-104', 'Purposive Communication', 'Communication skills development', 0, 3, 3, TRUE),
    ('GE-105', 'Art Appreciation', 'Understanding visual and performing arts', 0, 3, 3, TRUE),
    ('GE-106', 'Science, Technology and Society', 'Impact of science and technology', 0, 3, 3, TRUE),
    ('GE-107', 'Ethics', 'Moral philosophy and ethical reasoning', 0, 3, 3, TRUE),
    ('GE-108', 'The Contemporary World', 'Globalization and world issues', 0, 3, 3, TRUE),
    ('PE-101', 'Physical Education 1', 'Physical fitness and wellness', 0, 2, 3, TRUE),
    ('NSTP-101', 'National Service Training Program 1', 'Civic welfare training', 0, 3, 3, TRUE);

CREATE TABLE Course_Prerequisites (
    prerequisite_id INT PRIMARY KEY AUTO_INCREMENT,
    course_id INT NOT NULL,
    prerequisite_course_id INT NOT NULL,
    is_corequisite BOOLEAN DEFAULT FALSE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE,
    FOREIGN KEY (prerequisite_course_id) REFERENCES Courses(course_id) ON DELETE CASCADE,
    CONSTRAINT unique_prerequisite UNIQUE (course_id, prerequisite_course_id),
    CONSTRAINT no_self_prerequisite CHECK (course_id != prerequisite_course_id),
    INDEX idx_course (course_id),
    INDEX idx_prerequisite_course (prerequisite_course_id)
);

CREATE TABLE Program_Curriculum (
    curriculum_id INT PRIMARY KEY AUTO_INCREMENT,
    program_id INT NOT NULL,
    course_id INT NOT NULL,
    year_level_id INT NOT NULL,
    semester_type_id INT NOT NULL,
    category_id INT NOT NULL,
    is_required BOOLEAN DEFAULT TRUE,
    curriculum_year VARCHAR(10) NOT NULL,
    effective_academic_year_id INT,
    sequence_number INT,
    is_active BOOLEAN DEFAULT TRUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (program_id) REFERENCES Programs(program_id) ON DELETE CASCADE,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id) ON DELETE CASCADE,
    FOREIGN KEY (year_level_id) REFERENCES Year_Levels(year_level_id),
    FOREIGN KEY (semester_type_id) REFERENCES Semester_Types(semester_type_id),
    FOREIGN KEY (category_id) REFERENCES Subject_Categories(category_id),
    FOREIGN KEY (effective_academic_year_id) REFERENCES Academic_Years(academic_year_id),
    CONSTRAINT unique_program_course_curriculum UNIQUE (program_id, course_id, curriculum_year),
    INDEX idx_program (program_id),
    INDEX idx_course (course_id),
    INDEX idx_year_level (year_level_id),
    INDEX idx_semester (semester_type_id),
    INDEX idx_category (category_id),
    INDEX idx_curriculum_year (curriculum_year),
    INDEX idx_active (is_active)
);

-- BSIT Program Curriculum

-- BSIT - 1st Year, 1st Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (1, 1, 1, 1, 1, TRUE, '2025', 1, 1, TRUE),   -- IT-111 Introduction to Computing
    (1, 2, 1, 1, 1, TRUE, '2025', 1, 2, TRUE),   -- IT-112 Computer Programming 1
    (1, 20, 1, 1, 3, TRUE, '2025', 1, 3, TRUE),  -- GE-101 Understanding the Self
    (1, 21, 1, 1, 3, TRUE, '2025', 1, 4, TRUE),  -- GE-102 Philippine History
    (1, 22, 1, 1, 3, TRUE, '2025', 1, 5, TRUE),  -- GE-103 Math in Modern World
    (1, 28, 1, 1, 3, TRUE, '2025', 1, 6, TRUE);  -- PE-101 Physical Education 1

-- BSIT - 1st Year, 2nd Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (1, 3, 1, 2, 1, TRUE, '2025', 1, 7, TRUE),   -- IT-121 Computer Programming 2
    (1, 23, 1, 2, 3, TRUE, '2025', 1, 8, TRUE),  -- GE-104 Purposive Communication
    (1, 24, 1, 2, 3, TRUE, '2025', 1, 9, TRUE),  -- GE-105 Art Appreciation
    (1, 25, 1, 2, 3, TRUE, '2025', 1, 10, TRUE), -- GE-106 Science, Technology and Society
    (1, 29, 1, 2, 3, TRUE, '2025', 1, 11, TRUE); -- NSTP-101 NSTP 1

-- BSIT - 2nd Year, 1st Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (1, 4, 2, 1, 1, TRUE, '2025', 1, 12, TRUE),  -- IT-211 Data Structures
    (1, 5, 2, 1, 1, TRUE, '2025', 1, 13, TRUE),  -- IT-212 Database Management
    (1, 26, 2, 1, 3, TRUE, '2025', 1, 14, TRUE), -- GE-107 Ethics
    (1, 27, 2, 1, 3, TRUE, '2025', 1, 15, TRUE); -- GE-108 Contemporary World

-- BSIT - 2nd Year, 2nd Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (1, 6, 2, 2, 1, TRUE, '2025', 1, 16, TRUE);  -- IT-221 Web Development

-- BSIT - 3rd Year, 1st Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (1, 7, 3, 1, 1, TRUE, '2025', 1, 17, TRUE),  -- IT-311 System Administration
    (1, 8, 3, 1, 1, TRUE, '2025', 1, 18, TRUE);  -- IT-312 Network Security

-- BSIT - 4th Year, 1st Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (1, 9, 4, 1, 1, TRUE, '2025', 1, 19, TRUE);  -- IT-411 Capstone Project 1

-- BSIT - 4th Year, 2nd Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (1, 10, 4, 2, 1, TRUE, '2025', 1, 20, TRUE); -- IT-412 Capstone Project 2


-- BSCS Program Curriculum

-- BSCS - 1st Year, 1st Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (2, 1, 1, 1, 1, TRUE, '2025', 1, 1, TRUE),   -- IT-111 Introduction to Computing
    (2, 2, 1, 1, 1, TRUE, '2025', 1, 2, TRUE),   -- IT-112 Computer Programming 1
    (2, 11, 1, 1, 1, TRUE, '2025', 1, 3, TRUE),  -- CS-111 Discrete Mathematics
    (2, 20, 1, 1, 3, TRUE, '2025', 1, 4, TRUE),  -- GE-101 Understanding the Self
    (2, 21, 1, 1, 3, TRUE, '2025', 1, 5, TRUE),  -- GE-102 Philippine History
    (2, 22, 1, 1, 3, TRUE, '2025', 1, 6, TRUE);  -- GE-103 Math in Modern World

-- BSCS - 1st Year, 2nd Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (2, 3, 1, 2, 1, TRUE, '2025', 1, 7, TRUE),   -- IT-121 Computer Programming 2
    (2, 23, 1, 2, 3, TRUE, '2025', 1, 8, TRUE),  -- GE-104 Purposive Communication
    (2, 24, 1, 2, 3, TRUE, '2025', 1, 9, TRUE),  -- GE-105 Art Appreciation
    (2, 25, 1, 2, 3, TRUE, '2025', 1, 10, TRUE); -- GE-106 Science, Technology and Society

-- BSCS - 2nd Year, 1st Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (2, 12, 2, 1, 1, TRUE, '2025', 1, 11, TRUE), -- CS-211 Advanced Data Structures
    (2, 13, 2, 1, 1, TRUE, '2025', 1, 12, TRUE), -- CS-212 Software Engineering
    (2, 26, 2, 1, 3, TRUE, '2025', 1, 13, TRUE), -- GE-107 Ethics
    (2, 27, 2, 1, 3, TRUE, '2025', 1, 14, TRUE); -- GE-108 Contemporary World

-- BSCS - 2nd Year, 2nd Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (2, 5, 2, 2, 1, TRUE, '2025', 1, 15, TRUE);  -- IT-212 Database Management

-- BSCS - 3rd Year, 1st Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (2, 14, 3, 1, 1, TRUE, '2025', 1, 16, TRUE), -- CS-311 Theory of Computation
    (2, 15, 3, 1, 1, TRUE, '2025', 1, 17, TRUE), -- CS-312 Artificial Intelligence
    (2, 16, 3, 1, 1, TRUE, '2025', 1, 18, TRUE); -- CS-321 Operating Systems

-- BSCS - 3rd Year, 2nd Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (2, 17, 3, 2, 1, TRUE, '2025', 1, 19, TRUE); -- CS-411 Compiler Design

-- BSCS - 4th Year, 1st Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (2, 18, 4, 1, 1, TRUE, '2025', 1, 20, TRUE); -- CS-412 Thesis 1

-- BSCS - 4th Year, 2nd Semester
INSERT INTO Program_Curriculum (program_id, course_id, year_level_id, semester_type_id, category_id, is_required, curriculum_year, effective_academic_year_id, sequence_number, is_active) VALUES
    (2, 19, 4, 2, 1, TRUE, '2025', 1, 21, TRUE); -- CS-421 Thesis 2
    
    
-- COURSE OFFERINGS (Actual Class Sections)
CREATE TABLE Course_Offerings (
    offering_id INT PRIMARY KEY AUTO_INCREMENT,
    course_id INT NOT NULL,
    semester_id INT NOT NULL,
    term_id INT NOT NULL,  
    instructor_id INT,
    section VARCHAR(10),
    max_students INT DEFAULT 40,
    offering_status ENUM('Open', 'Closed', 'Cancelled', 'Full') DEFAULT 'Open',
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (course_id) REFERENCES Courses(course_id),
    FOREIGN KEY (semester_id) REFERENCES Semesters(semester_id),
    FOREIGN KEY (term_id) REFERENCES Terms(term_id),  
    FOREIGN KEY (instructor_id) REFERENCES Instructors(instructor_id) ON DELETE SET NULL,
    CONSTRAINT unique_offering UNIQUE (course_id, semester_id, term_id, section),
    INDEX idx_course (course_id),
    INDEX idx_semester (semester_id),
    INDEX idx_term (term_id),  
    INDEX idx_instructor (instructor_id),
    INDEX idx_status (offering_status)
);

INSERT INTO Course_Offerings (course_id, semester_id, term_id, instructor_id, section, max_students, offering_status) VALUES
    (1, 1, 1, 1, 'A', 40, 'Open'),
    (2, 1, 1, 2, 'A', 35, 'Open');

-- SCHEDULE MANAGEMENT (NORMALIZED)
CREATE TABLE Course_Schedules (
    schedule_id INT PRIMARY KEY AUTO_INCREMENT,
    offering_id INT NOT NULL,
    day_id INT NOT NULL,
    room_id INT,
    start_time TIME NOT NULL,
    end_time TIME NOT NULL,
    schedule_type ENUM('Lecture', 'Laboratory', 'Recitation', 'Online') DEFAULT 'Lecture',
    is_active BOOLEAN DEFAULT TRUE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    FOREIGN KEY (offering_id) REFERENCES Course_Offerings(offering_id) ON DELETE CASCADE,
    FOREIGN KEY (day_id) REFERENCES Days_Of_Week(day_id),
    FOREIGN KEY (room_id) REFERENCES Rooms(room_id) ON DELETE SET NULL,
    
    CONSTRAINT unique_offering_day_time UNIQUE (offering_id, day_id, start_time),
    CONSTRAINT chk_time_sequence CHECK (end_time > start_time),
    
    INDEX idx_offering (offering_id),
    INDEX idx_day (day_id),
    INDEX idx_room (room_id),
    INDEX idx_times (start_time, end_time),
    INDEX idx_active (is_active)
);

INSERT INTO Course_Schedules (offering_id, day_id, room_id, start_time, end_time, schedule_type, is_active) VALUES
    (1, 1, 1, '08:00:00', '10:00:00', 'Lecture', TRUE),
    (2, 2, 3, '10:00:00', '12:00:00', 'Laboratory', TRUE);

-- ============================================
-- GRADING CONFIGURATION
-- ============================================

-- Offering-specific grading configuration
CREATE TABLE Offering_Grading_Weights (
    weight_id INT PRIMARY KEY AUTO_INCREMENT,
    offering_id INT NOT NULL,
    type_id INT NOT NULL,
    period_id INT,
    custom_weight DECIMAL(5,2) NOT NULL,
    max_score DECIMAL(5,2),
    notes VARCHAR(255),
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (offering_id) REFERENCES Course_Offerings(offering_id) ON DELETE CASCADE,
    FOREIGN KEY (type_id) REFERENCES AssignmentTypes(type_id),
    FOREIGN KEY (period_id) REFERENCES Grading_Periods(period_id),
    CONSTRAINT unique_offering_weight UNIQUE (offering_id, type_id, period_id),
    CONSTRAINT chk_custom_weight CHECK (custom_weight >= 0 AND custom_weight <= 100),
    CONSTRAINT chk_max_score CHECK (max_score > 0),
    INDEX idx_offering (offering_id),
    INDEX idx_type (type_id),
    INDEX idx_period (period_id)
);

-- PRELIM PERIOD (33.33% of final grade)
INSERT INTO Offering_Grading_Weights (offering_id, type_id, period_id, custom_weight, max_score, notes) VALUES
(1, 1, 1, 16.67, 100, 'Quiz - Prelim'),           
(1, 2, 1, 15.00, 100, 'Assignments - Prelim'),    
(1, 3, 1, 10.00, 100, 'Participation - Prelim'),  
(1, 4, 1, 33.33, 100, 'Exam - Prelim'),          
(1, 5, 1, 25.00, 300,  'Labs - Prelim');          

-- MIDTERM PERIOD (33.33% of final grade)
INSERT INTO Offering_Grading_Weights (offering_id, type_id, period_id, custom_weight, max_score, notes) VALUES
(1, 1, 2, 16.67, 100, 'Quiz - Midterm'),
(1, 2, 2, 15.00, 100, 'Assignments - Midterm'),
(1, 3, 2, 10.00, 100, 'Participation - Midterm'),
(1, 4, 2, 33.33, 100, 'Exam - Midterm'),
(1, 5, 2, 25.00, 300,  'Labs - Midterm');

-- FINALS PERIOD (33.34% of final grade)
INSERT INTO Offering_Grading_Weights (offering_id, type_id, period_id, custom_weight, max_score, notes) VALUES
(1, 1, 3, 16.67, 100, 'Quiz - Finals'),
(1, 2, 3, 15.00, 100, 'Assignments - Finals'),
(1, 3, 3, 10.00, 100, 'Participation - Finals'),
(1, 4, 3, 33.34, 100, 'Exam - Finals'),
(1, 5, 3, 25.00, 300,  'Labs - Finals');

-- ============================================
-- ENROLLMENT AND GRADES
-- ============================================

CREATE TABLE Enrollments (
    enrollment_id INT PRIMARY KEY AUTO_INCREMENT,
    student_id INT NOT NULL,
    offering_id INT NOT NULL,
    enrollment_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    status_id INT NOT NULL DEFAULT 1,
    drop_date DATETIME,
    completion_date DATETIME,
    remarks TEXT,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (student_id) REFERENCES Students(student_id) ON DELETE CASCADE,
    FOREIGN KEY (offering_id) REFERENCES Course_Offerings(offering_id) ON DELETE CASCADE,
    FOREIGN KEY (status_id) REFERENCES Enrollment_Status_Types(status_id),
    CONSTRAINT unique_enrollment UNIQUE (student_id, offering_id),
    INDEX idx_student (student_id),
    INDEX idx_offering (offering_id),
    INDEX idx_status (status_id),
    INDEX idx_enrollment_date (enrollment_date)
);

-- ============================================
-- PER-PERIOD GRADES
-- ============================================

CREATE TABLE Grades (
    grade_id INT PRIMARY KEY AUTO_INCREMENT,
    enrollment_id INT NOT NULL,
    term_period_id INT NOT NULL,
    type_id INT,
    numeric_grade DECIMAL(5,2) NOT NULL,
    grade_date DATE NOT NULL,
    graded_by INT,
    notes TEXT,
    is_excused BOOLEAN DEFAULT FALSE,
    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (enrollment_id) REFERENCES Enrollments(enrollment_id) ON DELETE CASCADE,
    FOREIGN KEY (term_period_id) REFERENCES Term_Grading_Periods(term_period_id),
    FOREIGN KEY (graded_by) REFERENCES Instructors(instructor_id),
    FOREIGN KEY (type_id) REFERENCES AssignmentTypes(type_id),
    CONSTRAINT chk_numeric_grade_positive CHECK (numeric_grade >= 0 AND numeric_grade <= 1000),
    CONSTRAINT unique_enrollment_term_period_type UNIQUE (enrollment_id, term_period_id, type_id),
    INDEX idx_enrollment (enrollment_id),
    INDEX idx_term_period (term_period_id),
    INDEX idx_grade_date (grade_date),
    INDEX idx_graded_by (graded_by),
    INDEX idx_type (type_id)
);

CREATE TABLE Final_Grades (
    grade_id INT PRIMARY KEY AUTO_INCREMENT,
    enrollment_id INT UNIQUE NOT NULL,

    prelim_grade DECIMAL(5,2),
    midterm_grade DECIMAL(5,2),
    finals_grade DECIMAL(5,2),

    overall_numeric_grade DECIMAL(5,2),
    gpa_points DECIMAL(3,2),

    is_passing BOOLEAN GENERATED ALWAYS AS (
        overall_numeric_grade >= 75
    ) VIRTUAL,
    is_incomplete BOOLEAN DEFAULT FALSE,
    is_delinquent BOOLEAN DEFAULT FALSE,

    graded_by INT,
    graded_date DATETIME,
    finalized_date DATETIME,
    remarks TEXT,

    created_at DATETIME DEFAULT CURRENT_TIMESTAMP,
    updated_at DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,

    FOREIGN KEY (enrollment_id) REFERENCES Enrollments(enrollment_id) ON DELETE CASCADE,
    FOREIGN KEY (graded_by) REFERENCES Instructors(instructor_id),

    CONSTRAINT chk_grade_ranges CHECK (
        (prelim_grade IS NULL OR prelim_grade BETWEEN 0 AND 100) AND
        (midterm_grade IS NULL OR midterm_grade BETWEEN 0 AND 100) AND
        (finals_grade IS NULL OR finals_grade BETWEEN 0 AND 100) AND
        (overall_numeric_grade IS NULL OR overall_numeric_grade BETWEEN 0 AND 100) AND
        (gpa_points IS NULL OR gpa_points BETWEEN 0 AND 5)
    ),

    INDEX idx_enrollment (enrollment_id),
    INDEX idx_overall_grade (overall_numeric_grade),
    INDEX idx_graded_by (graded_by),
    INDEX idx_passing (is_passing)
);

-- GRADE HISTORY (AUDIT)
CREATE TABLE Grade_History (
    history_id INT PRIMARY KEY AUTO_INCREMENT,
    changed_at DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    changed_by INT NOT NULL,         
    grade_id INT,                     
    final_grade_id INT,               
    field_changed VARCHAR(100) NOT NULL,
    old_value VARCHAR(255),
    new_value VARCHAR(255),
    change_reason VARCHAR(255),
    FOREIGN KEY (changed_by) REFERENCES Users(user_id),
    FOREIGN KEY (grade_id) REFERENCES Grades(grade_id) ON DELETE SET NULL,
    FOREIGN KEY (final_grade_id) REFERENCES Final_Grades(grade_id) ON DELETE SET NULL,
    INDEX idx_changed_by (changed_by),
    INDEX idx_changed_at (changed_at),
    INDEX idx_grade (grade_id),
    INDEX idx_final_grade (final_grade_id)
);



CREATE VIEW StudentGradeSummary AS
SELECT 
    -- Student Information
    s.student_id,
    s.student_number,
    CONCAT(s.first_name, ' ', 
           CASE WHEN s.middle_name IS NOT NULL 
                THEN CONCAT(LEFT(s.middle_name, 1), '. ') 
                ELSE '' 
           END,
           s.last_name) AS student_name,
    s.email AS student_email,
    
    -- Program & Year Level
    p.program_code,
    p.program_name,
    yl.year_number,
    yl.year_level_name,
    
    -- Academic Period
    ay.academic_year_name,
    st.type_name AS semester_name,
    tt.type_name AS term_name,
    
    -- Course Information
    c.course_code,
    c.course_name,
    c.lecture_units,
    c.lab_units,
    c.credits AS total_units,
    
    -- Offering Details
    co.section,
    CONCAT(i.first_name, ' ', i.last_name) AS instructor_name,
    i.email AS instructor_email,
    
    -- Enrollment Status
    est.status_name AS enrollment_status,
    est.is_active_status AS is_currently_enrolled,
    e.enrollment_date,
    e.drop_date,
    e.completion_date,
    
    -- Period Grades (Prelim, Midterm, Finals)
    fg.prelim_grade,
    fg.midterm_grade,
    fg.finals_grade,
    
    -- Overall Grade
    fg.overall_numeric_grade,
    fg.gpa_points,
    fg.is_passing,
    fg.is_incomplete,
    fg.is_delinquent,
    
    -- Grade Status
    CASE 
        WHEN fg.overall_numeric_grade IS NULL THEN 'In Progress'
        WHEN fg.is_incomplete = TRUE THEN 'Incomplete'
        WHEN fg.is_delinquent = TRUE THEN 'Delinquent'
        WHEN fg.is_passing = TRUE THEN 'Passed'
        ELSE 'Failed'
    END AS grade_status,
    
    -- Grading Information
    fg.graded_date,
    fg.finalized_date,
    CONCAT(grader.first_name, ' ', grader.last_name) AS graded_by_name,
    
    -- Schedule Information (Aggregated)
    GROUP_CONCAT(
        DISTINCT CONCAT(
            dow.day_name, ' ',
            TIME_FORMAT(cs.start_time, '%h:%i %p'), '-',
            TIME_FORMAT(cs.end_time, '%h:%i %p')
        ) 
        ORDER BY dow.display_order 
        SEPARATOR ', '
    ) AS class_schedule,
    
    GROUP_CONCAT(
        DISTINCT CONCAT(r.room_code, ' (', r.building, ')')
        ORDER BY dow.display_order
        SEPARATOR ', '
    ) AS class_rooms,
    
    -- Remarks
    fg.remarks AS grade_remarks,
    e.remarks AS enrollment_remarks,
    
    -- Timestamps
    e.created_at AS enrollment_created_at,
    fg.updated_at AS grade_last_updated

FROM 
    Students s
    
    -- Join enrollment and course offering
    INNER JOIN Enrollments e ON s.student_id = e.student_id
    INNER JOIN Course_Offerings co ON e.offering_id = co.offering_id
    
    -- Join course and instructor
    INNER JOIN Courses c ON co.course_id = c.course_id
    LEFT JOIN Instructors i ON co.instructor_id = i.instructor_id
    
    -- Join academic calendar
    INNER JOIN Terms t ON co.term_id = t.term_id
    INNER JOIN Semesters sem ON t.semester_id = sem.semester_id
    INNER JOIN Academic_Years ay ON sem.academic_year_id = ay.academic_year_id
    INNER JOIN Semester_Types st ON sem.semester_type_id = st.semester_type_id
    INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id
    
    -- Join program and year level
    LEFT JOIN Programs p ON s.program_id = p.program_id
    LEFT JOIN Year_Levels yl ON s.year_level_id = yl.year_level_id
    
    -- Join enrollment status
    INNER JOIN Enrollment_Status_Types est ON e.status_id = est.status_id
    
    -- Join grades (left join since grades may not exist yet)
    LEFT JOIN Final_Grades fg ON e.enrollment_id = fg.enrollment_id
    LEFT JOIN Instructors grader ON fg.graded_by = grader.instructor_id
    
    -- Join schedule information
    LEFT JOIN Course_Schedules cs ON co.offering_id = cs.offering_id AND cs.is_active = TRUE
    LEFT JOIN Days_Of_Week dow ON cs.day_id = dow.day_id
    LEFT JOIN Rooms r ON cs.room_id = r.room_id

WHERE 
    s.user_id IN (SELECT user_id FROM Users WHERE is_active = TRUE)

GROUP BY
    s.student_id,
    s.student_number,
    s.first_name,
    s.middle_name,
    s.last_name,
    s.email,
    p.program_code,
    p.program_name,
    yl.year_number,
    yl.year_level_name,
    ay.academic_year_name,
    st.type_name,
    tt.type_name,
    c.course_code,
    c.course_name,
    c.lecture_units,
    c.lab_units,
    c.credits,
    co.section,
    i.first_name,
    i.last_name,
    i.email,
    est.status_name,
    est.is_active_status,
    e.enrollment_id,
    e.enrollment_date,
    e.drop_date,
    e.completion_date,
    e.remarks,
    fg.prelim_grade,
    fg.midterm_grade,
    fg.finals_grade,
    fg.overall_numeric_grade,
    fg.gpa_points,
    fg.is_passing,
    fg.is_incomplete,
    fg.is_delinquent,
    fg.graded_date,
    fg.finalized_date,
    fg.remarks,
    grader.first_name,
    grader.last_name,
    e.created_at,
    fg.updated_at

ORDER BY
    s.student_id,
    ay.year_start DESC,
    st.display_order,
    tt.display_order,
    c.course_code;


-- View for Instructor
CREATE VIEW TeacherCourseOverview AS
SELECT 
    -- Instructor Information
    i.instructor_id,
    CONCAT(i.first_name, ' ', 
           CASE WHEN i.middle_name IS NOT NULL 
                THEN CONCAT(LEFT(i.middle_name, 1), '. ') 
                ELSE '' 
           END,
           i.last_name) AS instructor_name,
    i.email AS instructor_email,
    d.department_name,
    d.department_code,
    
    -- Academic Period
    ay.academic_year_id,
    ay.academic_year_name,
    sem.semester_id,
    st.type_name AS semester_name,
    st.type_code AS semester_code,
    t.term_id,
    tt.type_name AS term_name,
    tt.type_code AS term_code,
    sem.is_active AS is_current_semester,
    t.is_active AS is_current_term,
    
    -- Course Information
    co.offering_id,
    c.course_id,
    c.course_code,
    c.course_name,
    c.lecture_units,
    c.lab_units,
    c.credits AS total_units,
    co.section,
    CONCAT(c.course_code, ' - ', co.section) AS course_section_display,
    
    -- Offering Details
    co.max_students,
    co.offering_status,
    
    -- Enrollment Statistics
    COUNT(DISTINCT e.enrollment_id) AS total_enrolled,
    COUNT(DISTINCT CASE 
        WHEN est.is_active_status = TRUE 
        THEN e.enrollment_id 
    END) AS active_enrollments,
    COUNT(DISTINCT CASE 
        WHEN est.status_name = 'Enrolled' 
        THEN e.enrollment_id 
    END) AS currently_enrolled,
    COUNT(DISTINCT CASE 
        WHEN est.status_name = 'Completed' 
        THEN e.enrollment_id 
    END) AS completed_count,
    COUNT(DISTINCT CASE 
        WHEN est.status_name = 'Dropped' 
        THEN e.enrollment_id 
    END) AS dropped_count,
    COUNT(DISTINCT CASE 
        WHEN est.status_name = 'Withdrawn' 
        THEN e.enrollment_id 
    END) AS withdrawn_count,
    
    -- Capacity Metrics
    co.max_students - COUNT(DISTINCT CASE 
        WHEN est.is_active_status = TRUE 
        THEN e.enrollment_id 
    END) AS available_slots,
    ROUND(
        (COUNT(DISTINCT CASE WHEN est.is_active_status = TRUE THEN e.enrollment_id END) 
         / co.max_students * 100), 
        2
    ) AS enrollment_percentage,
    
    -- Grade Statistics (from Final_Grades)
    COUNT(DISTINCT CASE 
        WHEN fg.overall_numeric_grade IS NOT NULL 
        THEN fg.grade_id 
    END) AS students_graded,
    COUNT(DISTINCT CASE 
        WHEN fg.overall_numeric_grade IS NULL 
        THEN e.enrollment_id 
    END) AS students_pending_grade,
    
    -- Passing/Failing Statistics
    COUNT(DISTINCT CASE 
        WHEN fg.is_passing = TRUE 
        THEN fg.grade_id 
    END) AS passing_count,
    COUNT(DISTINCT CASE 
        WHEN fg.is_passing = FALSE 
        THEN fg.grade_id 
    END) AS failing_count,
    COUNT(DISTINCT CASE 
        WHEN fg.is_incomplete = TRUE 
        THEN fg.grade_id 
    END) AS incomplete_count,
    COUNT(DISTINCT CASE 
        WHEN fg.is_delinquent = TRUE 
        THEN fg.grade_id 
    END) AS delinquent_count,
    
    -- Average Grades
    ROUND(AVG(fg.overall_numeric_grade), 2) AS class_average,
    ROUND(AVG(fg.prelim_grade), 2) AS prelim_average,
    ROUND(AVG(fg.midterm_grade), 2) AS midterm_average,
    ROUND(AVG(fg.finals_grade), 2) AS finals_average,
    ROUND(AVG(fg.gpa_points), 2) AS average_gpa,
    
    -- Grade Distribution
    MIN(fg.overall_numeric_grade) AS lowest_grade,
    MAX(fg.overall_numeric_grade) AS highest_grade,
    
    -- Passing Rate
    CASE 
        WHEN COUNT(DISTINCT CASE WHEN fg.overall_numeric_grade IS NOT NULL THEN fg.grade_id END) > 0
        THEN ROUND(
            (COUNT(DISTINCT CASE WHEN fg.is_passing = TRUE THEN fg.grade_id END) * 100.0 
             / COUNT(DISTINCT CASE WHEN fg.overall_numeric_grade IS NOT NULL THEN fg.grade_id END)),
            2
        )
        ELSE NULL
    END AS passing_rate,
    
    -- Schedule Information (Aggregated)
    GROUP_CONCAT(
        DISTINCT CONCAT(
            dow.day_name, ' ',
            TIME_FORMAT(cs.start_time, '%h:%i %p'), '-',
            TIME_FORMAT(cs.end_time, '%h:%i %p'),
            ' (', cs.schedule_type, ')'
        ) 
        ORDER BY dow.display_order 
        SEPARATOR '; '
    ) AS schedule_details,
    
    GROUP_CONCAT(
        DISTINCT CONCAT(r.room_code, ' - ', r.room_name, ', ', r.building)
        ORDER BY dow.display_order
        SEPARATOR '; '
    ) AS room_details,
    
    -- Period Completion Status
    CASE 
        WHEN EXISTS (
            SELECT 1 FROM Term_Grading_Periods tgp
            WHERE tgp.term_id = t.term_id 
              AND tgp.period_id = 1 
              AND tgp.is_active = FALSE
        ) THEN 'Completed'
        WHEN EXISTS (
            SELECT 1 FROM Term_Grading_Periods tgp
            WHERE tgp.term_id = t.term_id 
              AND tgp.period_id = 1 
              AND tgp.is_active = TRUE
        ) THEN 'In Progress'
        ELSE 'Not Started'
    END AS prelim_status,
    
    CASE 
        WHEN EXISTS (
            SELECT 1 FROM Term_Grading_Periods tgp
            WHERE tgp.term_id = t.term_id 
              AND tgp.period_id = 2 
              AND tgp.is_active = FALSE
        ) THEN 'Completed'
        WHEN EXISTS (
            SELECT 1 FROM Term_Grading_Periods tgp
            WHERE tgp.term_id = t.term_id 
              AND tgp.period_id = 2 
              AND tgp.is_active = TRUE
        ) THEN 'In Progress'
        ELSE 'Not Started'
    END AS midterm_status,
    
    CASE 
        WHEN EXISTS (
            SELECT 1 FROM Term_Grading_Periods tgp
            WHERE tgp.term_id = t.term_id 
              AND tgp.period_id = 3 
              AND tgp.is_active = FALSE
        ) THEN 'Completed'
        WHEN EXISTS (
            SELECT 1 FROM Term_Grading_Periods tgp
            WHERE tgp.term_id = t.term_id 
              AND tgp.period_id = 3 
              AND tgp.is_active = TRUE
        ) THEN 'In Progress'
        ELSE 'Not Started'
    END AS finals_status,
    
    -- Current Grading Period
    (
        SELECT gp.period_name
        FROM Term_Grading_Periods tgp
        JOIN Grading_Periods gp ON tgp.period_id = gp.period_id
        WHERE tgp.term_id = t.term_id 
          AND tgp.is_active = TRUE
        LIMIT 1
    ) AS current_grading_period,
    
    -- Progress Indicators
    CASE 
        WHEN COUNT(DISTINCT CASE WHEN fg.overall_numeric_grade IS NOT NULL THEN fg.grade_id END) = 0
        THEN 'No Grades Submitted'
        WHEN COUNT(DISTINCT CASE WHEN fg.overall_numeric_grade IS NULL AND est.is_active_status = TRUE THEN e.enrollment_id END) = 0
        THEN 'All Grades Complete'
        ELSE 'Grading In Progress'
    END AS grading_status,
    
    -- Alert Flags
    CASE 
        WHEN COUNT(DISTINCT CASE WHEN fg.is_passing = FALSE THEN fg.grade_id END) > 
             (COUNT(DISTINCT CASE WHEN fg.overall_numeric_grade IS NOT NULL THEN fg.grade_id END) * 0.3)
        THEN TRUE
        ELSE FALSE
    END AS high_failure_rate_alert,
    
    CASE 
        WHEN COUNT(DISTINCT CASE WHEN est.is_active_status = TRUE THEN e.enrollment_id END) < 
             (co.max_students * 0.5)
        THEN TRUE
        ELSE FALSE
    END AS low_enrollment_alert,
    
    -- Timestamps
    MIN(e.enrollment_date) AS first_enrollment_date,
    MAX(e.enrollment_date) AS last_enrollment_date,
    MAX(fg.updated_at) AS last_grade_update,
    co.created_at AS offering_created_at,
    co.updated_at AS offering_updated_at

FROM 
    Instructors i
    
    -- Join course offerings taught by this instructor
    LEFT JOIN Course_Offerings co ON i.instructor_id = co.instructor_id
    
    -- Join course details
    LEFT JOIN Courses c ON co.course_id = c.course_id
    
    -- Join academic calendar
    LEFT JOIN Terms t ON co.term_id = t.term_id
    LEFT JOIN Term_Types tt ON t.term_type_id = tt.term_type_id
    LEFT JOIN Semesters sem ON t.semester_id = sem.semester_id
    LEFT JOIN Semester_Types st ON sem.semester_type_id = st.semester_type_id
    LEFT JOIN Academic_Years ay ON sem.academic_year_id = ay.academic_year_id
    
    -- Join department
    LEFT JOIN Departments d ON i.department_id = d.department_id
    
    -- Join enrollments
    LEFT JOIN Enrollments e ON co.offering_id = e.offering_id
    LEFT JOIN Enrollment_Status_Types est ON e.status_id = est.status_id
    
    -- Join grades
    LEFT JOIN Final_Grades fg ON e.enrollment_id = fg.enrollment_id
    
    -- Join schedule information
    LEFT JOIN Course_Schedules cs ON co.offering_id = cs.offering_id AND cs.is_active = TRUE
    LEFT JOIN Days_Of_Week dow ON cs.day_id = dow.day_id
    LEFT JOIN Rooms r ON cs.room_id = r.room_id

WHERE 
    -- Only active instructors
    i.employment_status = 'Active'
    -- Only courses that exist (not orphaned instructors)
    AND co.offering_id IS NOT NULL

GROUP BY
    i.instructor_id,
    i.first_name,
    i.middle_name,
    i.last_name,
    i.email,
    d.department_name,
    d.department_code,
    ay.academic_year_id,
    ay.academic_year_name,
    sem.semester_id,
    st.type_name,
    st.type_code,
    t.term_id,
    tt.type_name,
    tt.type_code,
    sem.is_active,
    t.is_active,
    co.offering_id,
    c.course_id,
    c.course_code,
    c.course_name,
    c.lecture_units,
    c.lab_units,
    c.credits,
    co.section,
    co.max_students,
    co.offering_status,
    co.created_at,
    co.updated_at

ORDER BY
    i.instructor_id,
    ay.year_start DESC,
    st.display_order,
    tt.display_order,
    c.course_code,
    co.section;


CREATE VIEW StudentTranscript AS
SELECT 
    -- Student Information
    s.student_id,
    s.student_number,
    CONCAT(s.last_name, ', ', s.first_name, 
           CASE WHEN s.middle_name IS NOT NULL 
                THEN CONCAT(' ', SUBSTRING(s.middle_name, 1, 1), '.') 
                ELSE '' 
           END) AS student_name,
    s.first_name,
    s.last_name,
    s.middle_name,
    s.email AS student_email,
    s.date_of_birth,
    s.admission_date,
    
    -- Program Information
    p.program_code,
    p.program_name,
    d.department_name,
    d.department_code,
    yl.year_number,
    yl.year_level_name AS current_year_level,
    
    -- Academic Term Information
    ay.academic_year_name,
    ay.year_start,
    ay.year_end,
    sem.semester_id,
    st.type_name AS semester_name,
    st.type_code AS semester_code,
    sem.start_date AS semester_start_date,
    sem.end_date AS semester_end_date,
    t.term_id,
    tt.type_name AS term_name,
    tt.type_code AS term_code,
    
    -- Course Information
    c.course_id,
    c.course_code,
    c.course_name,
    c.course_description,
    c.lecture_units,
    c.lab_units,
    c.credits AS total_units,
    sc.category_name AS subject_category,
    sc.category_code,
    
    -- Course Offering Information
    co.offering_id,
    co.section,
    co.offering_status,
    
    -- Instructor Information
    CONCAT(i.last_name, ', ', i.first_name, 
           CASE WHEN i.middle_name IS NOT NULL 
                THEN CONCAT(' ', SUBSTRING(i.middle_name, 1, 1), '.') 
                ELSE '' 
           END) AS instructor_name,
    i.instructor_id,
    
    -- Enrollment Information
    e.enrollment_id,
    e.enrollment_date,
    est.status_name AS enrollment_status,
    est.is_active_status AS is_currently_enrolled,
    e.drop_date,
    e.completion_date,
    
    -- Final Grades
    fg.prelim_grade,
    fg.midterm_grade,
    fg.finals_grade,
    fg.overall_numeric_grade,
    fg.gpa_points,
    
    -- Letter Grade Conversion
    CASE 
        WHEN fg.overall_numeric_grade IS NULL THEN 'NG'
        WHEN fg.is_incomplete = TRUE THEN 'INC'
        WHEN fg.overall_numeric_grade >= 97.5 THEN '1.00'
        WHEN fg.overall_numeric_grade >= 94.5 THEN '1.25'
        WHEN fg.overall_numeric_grade >= 91.5 THEN '1.50'
        WHEN fg.overall_numeric_grade >= 88.5 THEN '1.75'
        WHEN fg.overall_numeric_grade >= 85.5 THEN '2.00'
        WHEN fg.overall_numeric_grade >= 82.5 THEN '2.25'
        WHEN fg.overall_numeric_grade >= 79.5 THEN '2.50'
        WHEN fg.overall_numeric_grade >= 76.5 THEN '2.75'
        WHEN fg.overall_numeric_grade >= 74.5 THEN '3.00'
        ELSE '5.00'
    END AS letter_grade,
    
    -- Grade Status
    fg.is_passing,
    fg.is_incomplete,
    fg.is_delinquent,
    fg.graded_date,
    fg.finalized_date,
    fg.remarks AS grade_remarks,
    
    -- Units Earned (only if passing)
    CASE 
        WHEN fg.is_passing = TRUE OR fg.overall_numeric_grade >= 75 
        THEN c.credits 
        ELSE 0 
    END AS units_earned,
    
    -- Schedule Information (concatenated for easier reading)
    (SELECT GROUP_CONCAT(
        CONCAT(dow.day_code, ' ', 
               DATE_FORMAT(cs.start_time, '%H:%i'), '-',
               DATE_FORMAT(cs.end_time, '%H:%i'), ' ',
               COALESCE(r.room_code, 'TBA'))
        SEPARATOR ', ')
     FROM Course_Schedules cs
     LEFT JOIN Days_Of_Week dow ON cs.day_id = dow.day_id
     LEFT JOIN Rooms r ON cs.room_id = r.room_id
     WHERE cs.offering_id = co.offering_id
       AND cs.is_active = TRUE
    ) AS schedule,
    
    -- Curriculum Information
    pc.sequence_number AS curriculum_sequence,
    pc.is_required AS is_required_course,
    pc.curriculum_year

FROM Students s
    
    -- Join Program and Department
    LEFT JOIN Programs p ON s.program_id = p.program_id
    LEFT JOIN Departments d ON s.department_id = d.department_id
    LEFT JOIN Year_Levels yl ON s.year_level_id = yl.year_level_id
    
    -- Join Enrollments
    LEFT JOIN Enrollments e ON s.student_id = e.student_id
    LEFT JOIN Enrollment_Status_Types est ON e.status_id = est.status_id
    
    -- Join Course Offerings
    LEFT JOIN Course_Offerings co ON e.offering_id = co.offering_id
    LEFT JOIN Courses c ON co.course_id = c.course_id
    
    -- Join Academic Calendar
    LEFT JOIN Terms t ON co.term_id = t.term_id
    LEFT JOIN Term_Types tt ON t.term_type_id = tt.term_type_id
    LEFT JOIN Semesters sem ON t.semester_id = sem.semester_id
    LEFT JOIN Semester_Types st ON sem.semester_type_id = st.semester_type_id
    LEFT JOIN Academic_Years ay ON sem.academic_year_id = ay.academic_year_id
    
    -- Join Instructor
    LEFT JOIN Instructors i ON co.instructor_id = i.instructor_id
    
    -- Join Final Grades
    LEFT JOIN Final_Grades fg ON e.enrollment_id = fg.enrollment_id
    
    -- Join Program Curriculum for additional context
    LEFT JOIN Program_Curriculum pc ON p.program_id = pc.program_id 
                                    AND c.course_id = pc.course_id
                                    AND pc.is_active = TRUE
    
    -- Join Subject Category
    LEFT JOIN Subject_Categories sc ON pc.category_id = sc.category_id

ORDER BY 
    s.student_number,
    ay.year_start DESC,
    st.display_order,
    tt.display_order,
    pc.sequence_number,
    c.course_code;


CREATE VIEW CoursePerformanceAnalytics AS
SELECT 
    -- Course Identification
    c.course_id,
    c.course_code,
    c.course_name,
    c.credits,
    c.lab_units,
    c.lecture_units,
    
    -- Department Information
    d.department_id,
    d.department_name,
    d.department_code,
    
    -- Subject Category
    sc.category_name AS subject_category,
    sc.category_code AS category_code,
    
    -- Semester/Term Information
    ay.academic_year_name,
    st.type_name AS semester_type,
    tt.type_name AS term_type,
    s.semester_id,
    t.term_id,
    
    -- Course Offering Details
    co.offering_id,
    co.section,
    co.max_students,
    co.offering_status,
    
    -- Instructor Information
    CONCAT(i.last_name, ', ', i.first_name) AS instructor_name,
    i. instructor_id,
    i.specialization AS instructor_specialization,
    
    -- Enrollment Statistics
    COUNT(DISTINCT e.enrollment_id) AS total_enrolled,
    COUNT(DISTINCT CASE WHEN est.status_name = 'Enrolled' THEN e.enrollment_id END) AS currently_enrolled,
    COUNT(DISTINCT CASE WHEN est.status_name = 'Completed' THEN e.enrollment_id END) AS completed_count,
    COUNT(DISTINCT CASE WHEN est.status_name = 'Dropped' THEN e.enrollment_id END) AS dropped_count,
    COUNT(DISTINCT CASE WHEN est. status_name = 'Withdrawn' THEN e.enrollment_id END) AS withdrawn_count,
    COUNT(DISTINCT CASE WHEN est.status_name = 'Failed' THEN e.enrollment_id END) AS failed_count,
    COUNT(DISTINCT CASE WHEN est.status_name = 'Incomplete' THEN e.enrollment_id END) AS incomplete_count,
    
    -- Capacity Metrics
    co.max_students - COUNT(DISTINCT e.enrollment_id) AS available_slots,
    ROUND((COUNT(DISTINCT e.enrollment_id) / co.max_students) * 100, 2) AS enrollment_percentage,
    
    -- Retention Rate
    ROUND(
        (COUNT(DISTINCT CASE WHEN est.status_name IN ('Enrolled', 'Completed') THEN e.enrollment_id END) / 
         NULLIF(COUNT(DISTINCT e.enrollment_id), 0)) * 100, 
        2
    ) AS retention_rate_percentage,
    
    -- Drop Rate
    ROUND(
        (COUNT(DISTINCT CASE WHEN est.status_name IN ('Dropped', 'Withdrawn') THEN e.enrollment_id END) / 
         NULLIF(COUNT(DISTINCT e. enrollment_id), 0)) * 100, 
        2
    ) AS drop_rate_percentage,
    
    -- Grade Statistics (from Final_Grades)
    COUNT(DISTINCT fg.grade_id) AS students_with_final_grades,
    ROUND(AVG(fg.overall_numeric_grade), 2) AS average_final_grade,
    ROUND(MIN(fg.overall_numeric_grade), 2) AS lowest_final_grade,
    ROUND(MAX(fg.overall_numeric_grade), 2) AS highest_final_grade,
    ROUND(STDDEV(fg.overall_numeric_grade), 2) AS grade_std_deviation,
    
    -- GPA Statistics
    ROUND(AVG(fg.gpa_points), 2) AS average_gpa,
    ROUND(MIN(fg.gpa_points), 2) AS lowest_gpa,
    ROUND(MAX(fg.gpa_points), 2) AS highest_gpa,
    
    -- Pass/Fail Analysis
    COUNT(CASE WHEN fg.is_passing = TRUE THEN 1 END) AS passing_students,
    COUNT(CASE WHEN fg.is_passing = FALSE THEN 1 END) AS failing_students,
    ROUND(
        (COUNT(CASE WHEN fg.is_passing = TRUE THEN 1 END) / 
         NULLIF(COUNT(fg.grade_id), 0)) * 100, 
        2
    ) AS pass_rate_percentage,
    
    -- Grade Distribution (A, B, C, D, F equivalent)
    COUNT(CASE WHEN fg.overall_numeric_grade >= 90 THEN 1 END) AS grade_a_count,
    COUNT(CASE WHEN fg.overall_numeric_grade >= 80 AND fg.overall_numeric_grade < 90 THEN 1 END) AS grade_b_count,
    COUNT(CASE WHEN fg.overall_numeric_grade >= 75 AND fg.overall_numeric_grade < 80 THEN 1 END) AS grade_c_count,
    COUNT(CASE WHEN fg.overall_numeric_grade >= 70 AND fg.overall_numeric_grade < 75 THEN 1 END) AS grade_d_count,
    COUNT(CASE WHEN fg.overall_numeric_grade < 70 THEN 1 END) AS grade_f_count,
    
    -- Grade Distribution Percentages
    ROUND((COUNT(CASE WHEN fg. overall_numeric_grade >= 90 THEN 1 END) / 
           NULLIF(COUNT(fg.grade_id), 0)) * 100, 2) AS grade_a_percentage,
    ROUND((COUNT(CASE WHEN fg.overall_numeric_grade >= 80 AND fg.overall_numeric_grade < 90 THEN 1 END) / 
           NULLIF(COUNT(fg.grade_id), 0)) * 100, 2) AS grade_b_percentage,
    ROUND((COUNT(CASE WHEN fg.overall_numeric_grade >= 75 AND fg.overall_numeric_grade < 80 THEN 1 END) / 
           NULLIF(COUNT(fg.grade_id), 0)) * 100, 2) AS grade_c_percentage,
    ROUND((COUNT(CASE WHEN fg.overall_numeric_grade >= 70 AND fg.overall_numeric_grade < 75 THEN 1 END) / 
           NULLIF(COUNT(fg.grade_id), 0)) * 100, 2) AS grade_d_percentage,
    ROUND((COUNT(CASE WHEN fg.overall_numeric_grade < 70 THEN 1 END) / 
           NULLIF(COUNT(fg.grade_id), 0)) * 100, 2) AS grade_f_percentage,
    
    -- Period Performance (Prelim, Midterm, Finals)
    ROUND(AVG(fg.prelim_grade), 2) AS average_prelim_grade,
    ROUND(AVG(fg.midterm_grade), 2) AS average_midterm_grade,
    ROUND(AVG(fg.finals_grade), 2) AS average_finals_grade,
    
    -- Incomplete/Delinquent Status
    COUNT(CASE WHEN fg.is_incomplete = TRUE THEN 1 END) AS incomplete_grades_count,
    COUNT(CASE WHEN fg.is_delinquent = TRUE THEN 1 END) AS delinquent_students_count,
    
    -- Performance Trend Indicator
    CASE 
        WHEN AVG(fg.overall_numeric_grade) >= 85 THEN 'Excellent'
        WHEN AVG(fg.overall_numeric_grade) >= 80 THEN 'Very Good'
        WHEN AVG(fg.overall_numeric_grade) >= 75 THEN 'Good'
        WHEN AVG(fg.overall_numeric_grade) >= 70 THEN 'Fair'
        ELSE 'Needs Improvement'
    END AS performance_rating,
    
    -- Risk Indicators
    CASE 
        WHEN (COUNT(CASE WHEN fg.is_passing = FALSE THEN 1 END) / 
              NULLIF(COUNT(fg.grade_id), 0)) > 0.30 THEN 'High Risk'
        WHEN (COUNT(CASE WHEN fg.is_passing = FALSE THEN 1 END) / 
              NULLIF(COUNT(fg.grade_id), 0)) > 0.15 THEN 'Medium Risk'
        ELSE 'Low Risk'
    END AS failure_risk_level,
    
    CASE 
        WHEN (COUNT(DISTINCT CASE WHEN est.status_name IN ('Dropped', 'Withdrawn') THEN e.enrollment_id END) / 
              NULLIF(COUNT(DISTINCT e.enrollment_id), 0)) > 0.20 THEN 'High Attrition'
        WHEN (COUNT(DISTINCT CASE WHEN est.status_name IN ('Dropped', 'Withdrawn') THEN e.enrollment_id END) / 
              NULLIF(COUNT(DISTINCT e.enrollment_id), 0)) > 0.10 THEN 'Moderate Attrition'
        ELSE 'Low Attrition'
    END AS attrition_risk_level,
    
    -- Timestamps
    co.created_at AS offering_created_at,
    co.updated_at AS offering_updated_at

FROM 
    Course_Offerings co
    INNER JOIN Courses c ON co.course_id = c.course_id
    INNER JOIN Semesters s ON co.semester_id = s.semester_id
    INNER JOIN Academic_Years ay ON s.academic_year_id = ay.academic_year_id
    INNER JOIN Semester_Types st ON s.semester_type_id = st.semester_type_id
    INNER JOIN Terms t ON co.term_id = t.term_id
    INNER JOIN Term_Types tt ON t.term_type_id = tt.term_type_id
    LEFT JOIN Departments d ON c.department_id = d.department_id
    LEFT JOIN Instructors i ON co.instructor_id = i.instructor_id
    LEFT JOIN Enrollments e ON co.offering_id = e.offering_id
    LEFT JOIN Enrollment_Status_Types est ON e.status_id = est.status_id
    LEFT JOIN Final_Grades fg ON e.enrollment_id = fg.enrollment_id
    LEFT JOIN Program_Curriculum pc ON c.course_id = pc.course_id AND pc.is_active = TRUE
    LEFT JOIN Subject_Categories sc ON pc.category_id = sc.category_id

GROUP BY 
    c.course_id,
    c.course_code,
    c.course_name,
    c.credits,
    c.lab_units,
    c.lecture_units,
    d.department_id,
    d.department_name,
    d.department_code,
    sc.category_name,
    sc.category_code,
    ay.academic_year_name,
    st.type_name,
    tt.type_name,
    s.semester_id,
    t.term_id,
    co.offering_id,
    co.section,
    co.max_students,
    co.offering_status,
    i.instructor_id,
    i.last_name,
    i.first_name,
    i.specialization,
    co. created_at,
    co.updated_at

ORDER BY 
    ay.academic_year_name DESC,
    st.display_order,
    tt.display_order,
    d.department_code,
    c.course_code,
    co.section;

-- Enroll Student
DELIMITER $$

DROP PROCEDURE IF EXISTS sp_EnrollStudent$$

CREATE PROCEDURE sp_EnrollStudent(
    IN p_student_id INT,
    IN p_offering_id INT,
    IN p_enrolled_by INT,  -- User ID of who is enrolling the student
    OUT p_enrollment_id INT,
    OUT p_status VARCHAR(50),
    OUT p_message VARCHAR(500)
)
proc_label: BEGIN
    -- Variable declarations
    DECLARE v_student_exists INT DEFAULT 0;
    DECLARE v_offering_exists INT DEFAULT 0;
    DECLARE v_max_students INT DEFAULT 0;
    DECLARE v_current_enrolled INT DEFAULT 0;
    DECLARE v_offering_status VARCHAR(20);
    DECLARE v_semester_active BOOLEAN DEFAULT FALSE;
    DECLARE v_term_active BOOLEAN DEFAULT FALSE;
    DECLARE v_course_id INT;
    DECLARE v_course_code VARCHAR(50);
    DECLARE v_course_name VARCHAR(255);
    DECLARE v_semester_id INT;
    DECLARE v_term_id INT;
    DECLARE v_instructor_id INT;
    DECLARE v_section VARCHAR(10);
    DECLARE v_student_program_id INT;
    DECLARE v_student_year_level INT;
    DECLARE v_already_enrolled INT DEFAULT 0;
    DECLARE v_duplicate_same_course INT DEFAULT 0;
    DECLARE v_prerequisites_met BOOLEAN DEFAULT TRUE;
    DECLARE v_missing_prereqs TEXT DEFAULT '';
    
    -- Error handling
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        -- Rollback on any error
        ROLLBACK;
        SET p_status = 'ERROR';
        SET p_message = 'An unexpected error occurred during enrollment. Transaction rolled back.';
        SET p_enrollment_id = NULL;
    END;
    
    -- Start transaction
    START TRANSACTION;
    
    -- Initialize output parameters
    SET p_enrollment_id = NULL;
    SET p_status = 'ERROR';
    SET p_message = '';
    
    -- VALIDATION 1: Check if student exists and is active
    SELECT COUNT(*), s.program_id, s.year_level_id
    INTO v_student_exists, v_student_program_id, v_student_year_level
    FROM Students s
    JOIN Users u ON s.user_id = u.user_id
    WHERE s.student_id = p_student_id 
        AND u.is_active = TRUE
    GROUP BY s.program_id, s.year_level_id;
    
    IF v_student_exists = 0 THEN
        SET p_status = 'ERROR';
        SET p_message = CONCAT('Student ID ', p_student_id, ' not found or account is inactive.');
        ROLLBACK;
        LEAVE proc_label;
    END IF;

    -- VALIDATION 2: Check if offering exists and get details
    SELECT 
        COUNT(*),
        co.max_students,
        co.offering_status,
        co.course_id,
        co.semester_id,
        co.term_id,
        co.instructor_id,
        co.section,
        c.course_code,
        c.course_name
    INTO 
        v_offering_exists,
        v_max_students,
        v_offering_status,
        v_course_id,
        v_semester_id,
        v_term_id,
        v_instructor_id,
        v_section,
        v_course_code,
        v_course_name
    FROM Course_Offerings co
    JOIN Courses c ON co.course_id = c.course_id
    WHERE co.offering_id = p_offering_id
        AND c.is_active = TRUE
    GROUP BY 
        co.max_students,
        co.offering_status,
        co.course_id,
        co.semester_id,
        co.term_id,
        co.instructor_id,
        co.section,
        c.course_code,
        c.course_name;
    
    IF v_offering_exists = 0 THEN
        SET p_status = 'ERROR';
        SET p_message = CONCAT('Course offering ID ', p_offering_id, ' not found or course is inactive.');
        ROLLBACK;
        LEAVE proc_label;
    END IF;
    
    -- VALIDATION 3: Check if semester/term is active
    SELECT s.is_active, t.is_active
    INTO v_semester_active, v_term_active
    FROM Semesters s
    JOIN Terms t ON s.semester_id = t.semester_id
    WHERE s.semester_id = v_semester_id
        AND t.term_id = v_term_id;
    
    IF NOT v_semester_active OR NOT v_term_active THEN
        SET p_status = 'ERROR';
        SET p_message = 'Cannot enroll: The semester or term is not currently active for enrollment.';
        ROLLBACK;
        LEAVE proc_label;
    END IF;
    
    -- VALIDATION 4: Check offering status
    IF v_offering_status = 'Cancelled' THEN
        SET p_status = 'ERROR';
        SET p_message = CONCAT('Course offering ', v_course_code, ' - Section ', v_section, ' has been cancelled.');
        ROLLBACK;
        LEAVE proc_label;
    END IF;
    
    IF v_offering_status = 'Closed' THEN
        SET p_status = 'ERROR';
        SET p_message = CONCAT('Course offering ', v_course_code, ' - Section ', v_section, ' is closed for enrollment.');
        ROLLBACK;
        LEAVE proc_label;
    END IF;
    
    -- VALIDATION 5: Check if class is full
    SELECT COUNT(*)
    INTO v_current_enrolled
    FROM Enrollments e
    JOIN Enrollment_Status_Types est ON e.status_id = est.status_id
    WHERE e.offering_id = p_offering_id
        AND est.is_active_status = TRUE;  -- Only count active enrollments
    
    IF v_current_enrolled >= v_max_students THEN
        SET p_status = 'ERROR';
        SET p_message = CONCAT('Course offering ', v_course_code, ' - Section ', v_section, 
                              ' is full. (', v_current_enrolled, '/', v_max_students, ' enrolled)');
        ROLLBACK;
        LEAVE proc_label;
    END IF;
    
    -- VALIDATION 6: Check if student is already enrolled in this offering
    SELECT COUNT(*)
    INTO v_already_enrolled
    FROM Enrollments e
    JOIN Enrollment_Status_Types est ON e.status_id = est.status_id
    WHERE e.student_id = p_student_id
        AND e.offering_id = p_offering_id
        AND est.is_active_status = TRUE;
    
    IF v_already_enrolled > 0 THEN
        SET p_status = 'ERROR';
        SET p_message = CONCAT('Student is already enrolled in ', v_course_code, ' - Section ', v_section, '.');
        ROLLBACK;
        LEAVE proc_label;
    END IF;
    
    -- VALIDATION 7: Check if student is enrolled in same course (different section) in same term
    SELECT COUNT(*)
    INTO v_duplicate_same_course
    FROM Enrollments e
    JOIN Course_Offerings co ON e.offering_id = co.offering_id
    JOIN Enrollment_Status_Types est ON e.status_id = est.status_id
    WHERE e.student_id = p_student_id
        AND co.course_id = v_course_id
        AND co.term_id = v_term_id
        AND e.offering_id != p_offering_id
        AND est.is_active_status = TRUE;
    
    IF v_duplicate_same_course > 0 THEN
        SET p_status = 'ERROR';
        SET p_message = CONCAT('Student is already enrolled in ', v_course_code, 
                              ' (different section) for this term.');
        ROLLBACK;
        LEAVE proc_label;
    END IF;
    
    -- VALIDATION 8: Check prerequisites
    -- Get list of missing prerequisites
    SELECT 
        GROUP_CONCAT(c.course_code ORDER BY c.course_code SEPARATOR ', ')
    INTO v_missing_prereqs
    FROM Course_Prerequisites cp
    JOIN Courses c ON cp.prerequisite_course_id = c.course_id
    WHERE cp.course_id = v_course_id
        AND cp.is_corequisite = FALSE
        AND NOT EXISTS (
            -- Check if student has completed the prerequisite
            SELECT 1
            FROM Enrollments e
            JOIN Final_Grades fg ON e.enrollment_id = fg.enrollment_id
            WHERE e.student_id = p_student_id
                AND e.offering_id IN (
                    SELECT offering_id 
                    FROM Course_Offerings 
                    WHERE course_id = cp.prerequisite_course_id
                )
                AND fg.is_passing = TRUE
        );
    
    IF v_missing_prereqs IS NOT NULL AND v_missing_prereqs != '' THEN
        SET p_status = 'ERROR';
        SET p_message = CONCAT('Missing prerequisites for ', v_course_code, ': ', v_missing_prereqs);
        ROLLBACK;
        LEAVE proc_label;
    END IF;
    
    -- VALIDATION 9: Check schedule conflicts
    IF EXISTS (
        SELECT 1
        FROM Enrollments e
        JOIN Course_Offerings co ON e.offering_id = co.offering_id
        JOIN Course_Schedules cs1 ON co.offering_id = cs1.offering_id
        JOIN Course_Schedules cs2 ON cs2.offering_id = p_offering_id
        JOIN Enrollment_Status_Types est ON e.status_id = est.status_id
        WHERE e.student_id = p_student_id
            AND co.term_id = v_term_id
            AND est.is_active_status = TRUE
            AND cs1.day_id = cs2.day_id
            AND cs1.is_active = TRUE
            AND cs2.is_active = TRUE
            AND (
                -- Check for time overlap
                (cs1.start_time < cs2.end_time AND cs1.end_time > cs2.start_time)
            )
    ) THEN
        SET p_status = 'WARNING';
        SET p_message = CONCAT('Schedule conflict detected for ', v_course_code, ' - Section ', v_section, '. Student has another class at the same time.');
    END IF;
    
    -- PERFORM ENROLLMENT
    INSERT INTO Enrollments (
        student_id,
        offering_id,
        enrollment_date,
        status_id,
        remarks
    ) VALUES (
        p_student_id,
        p_offering_id,
        NOW(),
        1,  -- Enrolled status
        CONCAT('Enrolled by user ID ', p_enrolled_by)
    );
    
    -- Get the new enrollment ID
    SET p_enrollment_id = LAST_INSERT_ID();
    
    -- UPDATE OFFERING STATUS IF NOW FULL
    IF (v_current_enrolled + 1) >= v_max_students THEN
        UPDATE Course_Offerings
        SET offering_status = 'Full',
            updated_at = NOW()
        WHERE offering_id = p_offering_id;
    END IF;
    
    -- UPDATE STUDENT'S CURRENT STATUS
    UPDATE Students
    SET current_status_id = 1,  -- Enrolled
        updated_at = NOW()
    WHERE student_id = p_student_id;
    
    -- Commit transaction
    COMMIT;
    
    -- SET SUCCESS STATUS
    IF p_status != 'WARNING' THEN
        SET p_status = 'SUCCESS';
        SET p_message = CONCAT('Successfully enrolled in ', v_course_code, ' - ', v_course_name, ' (Section ', v_section, ')');
    ELSE
        -- Keep WARNING status but append success message
        SET p_message = CONCAT(p_message, ' Enrollment completed successfully.');
    END IF;
    
    -- RETURN ENROLLMENT DETAILS
    SELECT 
        p_enrollment_id AS enrollment_id,
        p_status AS status,
        p_message AS message,
        v_course_code AS course_code,
        v_course_name AS course_name,
        v_section AS section,
        CONCAT(i.first_name, ' ', i.last_name) AS instructor_name,
        (v_current_enrolled + 1) AS enrolled_count,
        v_max_students AS max_students,
        NOW() AS enrollment_date
    FROM Instructors i
    WHERE i.instructor_id = v_instructor_id;
    
END$$

DELIMITER ;


-- Calculate Final Grade
DELIMITER $$

DROP PROCEDURE IF EXISTS sp_CalculateCourseGrade$$

CREATE PROCEDURE sp_CalculateCourseGrade(
    IN p_enrollment_id INT,
    IN p_graded_by INT
)
BEGIN
    -- Variable declarations
    DECLARE v_prelim_grade DECIMAL(5,2) DEFAULT 0.00;
    DECLARE v_midterm_grade DECIMAL(5,2) DEFAULT 0.00;
    DECLARE v_finals_grade DECIMAL(5,2) DEFAULT 0.00;
    DECLARE v_overall_grade DECIMAL(5,2) DEFAULT 0.00;
    DECLARE v_gpa_points DECIMAL(3,2) DEFAULT 0.00;
    DECLARE v_offering_id INT;
    DECLARE v_student_id INT;
    DECLARE v_term_id INT;
    
    -- Error handling variables
    DECLARE v_error_msg VARCHAR(255);
    DECLARE v_has_error BOOLEAN DEFAULT FALSE;
    
    -- Cursor variables for period calculation
    DECLARE v_period_id INT;
    DECLARE v_period_weight DECIMAL(5,2);
    DECLARE v_period_grade DECIMAL(5,2);
    DECLARE v_done INT DEFAULT FALSE;
    
    -- Declare cursor for grading periods
    DECLARE period_cursor CURSOR FOR
        SELECT gp.period_id, gp.period_weight
        FROM Grading_Periods gp
        ORDER BY gp.display_order;
    
    -- Declare continue handler
    DECLARE CONTINUE HANDLER FOR NOT FOUND SET v_done = TRUE;
    
    -- Error handler
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        -- Rollback on error
        ROLLBACK;
        -- Return error message
        SELECT 'ERROR' AS status, 
               CONCAT('An error occurred: ', IFNULL(v_error_msg, 'Unknown error')) AS message;
    END;
    
    -- Start transaction
    START TRANSACTION;
    
    -- Check if enrollment exists
    SELECT e.offering_id, e.student_id, co.term_id
    INTO v_offering_id, v_student_id, v_term_id
    FROM Enrollments e
    JOIN Course_Offerings co ON e.offering_id = co.offering_id
    WHERE e.enrollment_id = p_enrollment_id;
    
    IF v_offering_id IS NULL THEN
        SET v_error_msg = CONCAT('Enrollment ID ', p_enrollment_id, ' not found');
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = v_error_msg;
    END IF;
    
    -- Check if enrollment is active
    IF NOT EXISTS (
        SELECT 1 FROM Enrollments 
        WHERE enrollment_id = p_enrollment_id 
        AND status_id = 1  -- Enrolled status
    ) THEN
        SET v_error_msg = 'Cannot calculate grade for non-enrolled student';
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = v_error_msg;
    END IF;
    
    -- CALCULATE GRADES FOR EACH PERIOD
    OPEN period_cursor;
    
    period_loop: LOOP
        FETCH period_cursor INTO v_period_id, v_period_weight;
        
        IF v_done THEN
            LEAVE period_loop;
        END IF;
        
        -- Calculate weighted grade for this period
        SET v_period_grade = 0.00;
        
        SELECT COALESCE(SUM(
            (g.numeric_grade / ogw.max_score * 100) * (ogw.custom_weight / 100)
        ), 0.00)
        INTO v_period_grade
        FROM Grades g
        JOIN Term_Grading_Periods tgp ON g.term_period_id = tgp.term_period_id
        JOIN Offering_Grading_Weights ogw ON g.type_id = ogw.type_id 
            AND ogw.offering_id = v_offering_id
            AND ogw.period_id = v_period_id
        WHERE g.enrollment_id = p_enrollment_id
            AND tgp.period_id = v_period_id
            AND tgp.term_id = v_term_id
            AND g.is_excused = FALSE;
        
        -- Assign to appropriate period variable
        CASE v_period_id
            WHEN 1 THEN SET v_prelim_grade = v_period_grade;
            WHEN 2 THEN SET v_midterm_grade = v_period_grade;
            WHEN 3 THEN SET v_finals_grade = v_period_grade;
        END CASE;
        
    END LOOP;
    
    CLOSE period_cursor;
    
    -- CALCULATE OVERALL GRADE
    
    -- Overall grade = weighted sum of all periods
    -- Default weights: Prelim 33.33%, Midterm 33.33%, Finals 33.34%
    SET v_overall_grade = ROUND(
        (v_prelim_grade * 0.3333) + 
        (v_midterm_grade * 0.3333) + 
        (v_finals_grade * 0.3334),
        2
    );
    
    -- CALCULATE GPA POINTS (Philippine Scale: 1.0 - 5.0)
    SET v_gpa_points = CASE
        WHEN v_overall_grade >= 97 THEN 1.00
        WHEN v_overall_grade >= 94 THEN 1.25
        WHEN v_overall_grade >= 91 THEN 1.50
        WHEN v_overall_grade >= 88 THEN 1.75
        WHEN v_overall_grade >= 85 THEN 2.00
        WHEN v_overall_grade >= 82 THEN 2.25
        WHEN v_overall_grade >= 79 THEN 2.50
        WHEN v_overall_grade >= 76 THEN 2.75
        WHEN v_overall_grade >= 75 THEN 3.00
        WHEN v_overall_grade >= 72 THEN 4.00
        ELSE 5.00  -- Failing grade
    END;
    
    -- INSERT OR UPDATE FINAL GRADES
    IF EXISTS (SELECT 1 FROM Final_Grades WHERE enrollment_id = p_enrollment_id) THEN
        -- Update existing record
        UPDATE Final_Grades
        SET 
            prelim_grade = v_prelim_grade,
            midterm_grade = v_midterm_grade,
            finals_grade = v_finals_grade,
            overall_numeric_grade = v_overall_grade,
            gpa_points = v_gpa_points,
            graded_by = p_graded_by,
            graded_date = NOW(),
            finalized_date = CASE 
                WHEN v_prelim_grade > 0 AND v_midterm_grade > 0 AND v_finals_grade > 0 
                THEN NOW() 
                ELSE NULL 
            END,
            updated_at = NOW()
        WHERE enrollment_id = p_enrollment_id;
        
        -- Log grade update in history
        INSERT INTO Grade_History (
            changed_by, 
            final_grade_id, 
            field_changed, 
            old_value, 
            new_value, 
            change_reason
        )
        SELECT 
            p_graded_by,
            grade_id,
            'overall_numeric_grade',
            CAST(overall_numeric_grade AS CHAR),
            CAST(v_overall_grade AS CHAR),
            'Grade recalculation via sp_CalculateCourseGrade'
        FROM Final_Grades
        WHERE enrollment_id = p_enrollment_id;
        
    ELSE
        -- Insert new record
        INSERT INTO Final_Grades (
            enrollment_id,
            prelim_grade,
            midterm_grade,
            finals_grade,
            overall_numeric_grade,
            gpa_points,
            graded_by,
            graded_date,
            finalized_date
        ) VALUES (
            p_enrollment_id,
            v_prelim_grade,
            v_midterm_grade,
            v_finals_grade,
            v_overall_grade,
            v_gpa_points,
            p_graded_by,
            NOW(),
            CASE 
                WHEN v_prelim_grade > 0 AND v_midterm_grade > 0 AND v_finals_grade > 0 
                THEN NOW() 
                ELSE NULL 
            END
        );
        
        -- Log grade creation in history
        INSERT INTO Grade_History (
            changed_by, 
            final_grade_id, 
            field_changed, 
            old_value, 
            new_value, 
            change_reason
        )
        VALUES (
            p_graded_by,
            LAST_INSERT_ID(),
            'overall_numeric_grade',
            NULL,
            CAST(v_overall_grade AS CHAR),
            'Initial grade calculation via sp_CalculateCourseGrade'
        );
    END IF;
    
    -- UPDATE ENROLLMENT STATUS IF COMPLETED
    IF v_prelim_grade > 0 AND v_midterm_grade > 0 AND v_finals_grade > 0 THEN
        UPDATE Enrollments
        SET 
            status_id = CASE 
                WHEN v_overall_grade >= 75 THEN 2  -- Completed
                ELSE 3  -- Failed
            END,
            completion_date = NOW(),
            updated_at = NOW()
        WHERE enrollment_id = p_enrollment_id;
    END IF;
    
    -- Commit transaction
    COMMIT;
    
    -- RETURN SUCCESS MESSAGE WITH GRADE DETAILS
    SELECT 
        'SUCCESS' AS status,
        'Grade calculated successfully' AS message,
        v_prelim_grade AS prelim_grade,
        v_midterm_grade AS midterm_grade,
        v_finals_grade AS finals_grade,
        v_overall_grade AS overall_grade,
        v_gpa_points AS gpa_points,
        CASE 
            WHEN v_overall_grade >= 75 THEN 'PASSED'
            ELSE 'FAILED'
        END AS grade_status,
        NOW() AS calculated_at;
        
END$$

DELIMITER ;
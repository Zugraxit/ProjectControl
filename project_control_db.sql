USE `ispp1114` ;

CREATE TABLE IF NOT EXISTS `ispp1114`.`user` (
  `id_user` INT NOT NULL AUTO_INCREMENT,
  `login` VARCHAR(30) NOT NULL,
  `password` VARCHAR(50) NOT NULL,
  `name` VARCHAR(30) NOT NULL,
  `image_path` VARCHAR(500) NULL,
  PRIMARY KEY (`id_user`),
  UNIQUE INDEX `login_UNIQUE` (`login` ASC) VISIBLE)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ispp1114`.`project` (
  `id_project` INT NOT NULL AUTO_INCREMENT,
  `id_admin` INT NOT NULL,
  `title` VARCHAR(50) NOT NULL,
  `description` VARCHAR(250) NULL,
  PRIMARY KEY (`id_project`),
  INDEX `fk_project_admin_idx` (`id_admin` ASC) VISIBLE,
  CONSTRAINT `fk_project_admin`
    FOREIGN KEY (`id_admin`)
    REFERENCES `ispp1114`.`user` (`id_user`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ispp1114`.`task` (
  `id_task` INT NOT NULL AUTO_INCREMENT,
  `id_project` INT NOT NULL,
  `id_user` INT NOT NULL,
  `title` VARCHAR(60) NOT NULL,
  `deadline` DATE NOT NULL,
  `status` ENUM('queue', 'progress', 'hold', 'complete') NOT NULL DEFAULT 'queue',
  PRIMARY KEY (`id_task`),
  INDEX `fk_task_project_idx` (`id_project` ASC) VISIBLE,
  INDEX `fk_task_user_idx` (`id_user` ASC) VISIBLE,
  CONSTRAINT `fk_task_project`
    FOREIGN KEY (`id_project`)
    REFERENCES `ispp1114`.`project` (`id_project`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_task_user`
    FOREIGN KEY (`id_user`)
    REFERENCES `ispp1114`.`user` (`id_user`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

CREATE TABLE IF NOT EXISTS `ispp1114`.`project_has_user` (
  `id_project` INT NOT NULL,
  `id_user` INT NOT NULL,
  PRIMARY KEY (`id_project`, `id_user`),
  INDEX `fk_user_has_project_project_idx` (`id_project` ASC) VISIBLE,
  INDEX `fk_user_has_project_user_idx` (`id_user` ASC) VISIBLE,
  CONSTRAINT `fk_user_has_project_user`
    FOREIGN KEY (`id_user`)
    REFERENCES `ispp1114`.`user` (`id_user`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `fk_user_has_project_project`
    FOREIGN KEY (`id_project`)
    REFERENCES `ispp1114`.`project` (`id_project`)
    ON DELETE CASCADE
    ON UPDATE CASCADE)
ENGINE = InnoDB;

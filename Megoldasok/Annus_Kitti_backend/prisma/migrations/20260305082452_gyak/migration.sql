-- CreateTable
CREATE TABLE `hos` (
    `id` INTEGER NOT NULL AUTO_INCREMENT,
    `nev` VARCHAR(255) NOT NULL,
    `szarmazas` VARCHAR(255) NOT NULL,
    `szint` INTEGER NOT NULL,
    `kasztId` INTEGER NULL,

    INDEX `kasztId`(`kasztId`),
    PRIMARY KEY (`id`)
) DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- CreateTable
CREATE TABLE `kaszt` (
    `id` INTEGER NOT NULL AUTO_INCREMENT,
    `nev` VARCHAR(255) NOT NULL,

    PRIMARY KEY (`id`)
) DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- AddForeignKey
ALTER TABLE `hos` ADD CONSTRAINT `hos_ibfk_1` FOREIGN KEY (`kasztId`) REFERENCES `kaszt`(`id`) ON DELETE RESTRICT ON UPDATE RESTRICT;

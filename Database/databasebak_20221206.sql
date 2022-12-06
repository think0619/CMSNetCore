/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 80030
 Source Host           : localhost:33306
 Source Schema         : databasebak

 Target Server Type    : MySQL
 Target Server Version : 80030
 File Encoding         : 65001

 Date: 06/12/2022 09:47:20
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for tb_dbbackinfo
-- ----------------------------
DROP TABLE IF EXISTS `tb_dbbackinfo`;
CREATE TABLE `tb_dbbackinfo`  (
  `RecId` bigint NOT NULL AUTO_INCREMENT,
  `DBName` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `BakDatetime` datetime NULL DEFAULT NULL,
  `FileName` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `FileAbsolutePath` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Status` tinyint NULL DEFAULT 1,
  `RecordTime` datetime NULL DEFAULT NULL,
  PRIMARY KEY (`RecId`) USING BTREE,
  INDEX `Status`(`Status`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of tb_dbbackinfo
-- ----------------------------
INSERT INTO `tb_dbbackinfo` VALUES (1, 'DBName', '2022-11-29 00:00:00', 'DBName', 'aaa', 1, '2022-11-29 15:00:32');
INSERT INTO `tb_dbbackinfo` VALUES (2, 'DBName', '2022-11-29 00:00:00', 'DBName', 'aaa', 1, '2022-11-29 15:05:29');
INSERT INTO `tb_dbbackinfo` VALUES (3, 'DBName', '2022-11-29 00:00:00', 'DBName', 'aaa', 1, '2022-11-29 15:06:36');
INSERT INTO `tb_dbbackinfo` VALUES (4, 'DBName', '2022-11-29 00:00:00', 'DBName', 'D:\\CodeTest\\TextVoiceServer.7z', 1, '2022-11-29 15:11:54');
INSERT INTO `tb_dbbackinfo` VALUES (5, 'DBName', '2022-11-29 00:00:00', 'DBName', 'aaa', 1, '2022-11-29 16:27:22');
INSERT INTO `tb_dbbackinfo` VALUES (6, 'DBName', '2022-11-29 00:00:00', 'FileName', 'FileAbsolutePath', 1, '2022-11-29 16:30:02');
INSERT INTO `tb_dbbackinfo` VALUES (7, 'DBName', '2022-11-29 00:00:00', 'DBName', 'aaa', 1, '2022-11-29 17:14:36');
INSERT INTO `tb_dbbackinfo` VALUES (8, 'DBName', '2022-11-29 00:00:00', 'DBName', 'abc', 1, '2022-11-29 17:14:53');

-- ----------------------------
-- Table structure for tb_loginuser
-- ----------------------------
DROP TABLE IF EXISTS `tb_loginuser`;
CREATE TABLE `tb_loginuser`  (
  `recid` int NOT NULL AUTO_INCREMENT,
  `UserName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Status` tinyint NULL DEFAULT 1,
  `UserInfo` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Remark` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`recid`) USING BTREE,
  INDEX `UserName`(`UserName`, `Status`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = DYNAMIC;

-- ----------------------------
-- Records of tb_loginuser
-- ----------------------------
INSERT INTO `tb_loginuser` VALUES (1, 'admin', '874c28934b0c3f9ed770d9194726352f', 1, '管理员', 'Xiongsen!+{:>-pl,(IJN*');
INSERT INTO `tb_loginuser` VALUES (2, 'Test', 'e10adc3949ba59abbe56e057f20f883e', 1, 'ceshi', '123456');

SET FOREIGN_KEY_CHECKS = 1;

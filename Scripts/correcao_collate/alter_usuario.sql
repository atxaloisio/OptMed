ALTER TABLE dbintegracao.usuario
 DROP FOREIGN KEY FK_usuario_perfil,
 CHANGE inativo inativo CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'indicado de usuario inativo S/N';
ALTER TABLE dbintegracao.usuario
 ADD CONSTRAINT FK_usuario_perfil FOREIGN KEY (Id_perfil) REFERENCES dbintegracao.perfil (Id) ON UPDATE RESTRICT ON DELETE RESTRICT;

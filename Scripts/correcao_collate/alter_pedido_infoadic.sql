ALTER TABLE dbintegracao.pedido_infoadic
 DROP FOREIGN KEY FK_pedido_infoadic_conta_corrente,
 DROP FOREIGN KEY FK_pedido_infoadic_pedido,
 CHANGE consumidor_final consumidor_final CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Consumidor Final (S/N)',
 CHANGE enviar_email enviar_email CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Enviar e-mail com Boleto, DANFE e XML';
ALTER TABLE dbintegracao.pedido_infoadic
 ADD CONSTRAINT FK_pedido_infoadic_conta_corrente FOREIGN KEY (Id_conta_corrente) REFERENCES dbintegracao.conta_corrente (Id) ON UPDATE RESTRICT ON DELETE RESTRICT,
 ADD CONSTRAINT FK_pedido_infoadic_pedido FOREIGN KEY (Id_Pedido) REFERENCES dbintegracao.pedido (id) ON UPDATE CASCADE ON DELETE CASCADE;

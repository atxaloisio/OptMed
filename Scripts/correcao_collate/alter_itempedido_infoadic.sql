ALTER TABLE dbintegracao.itempedido_infoadic
 DROP FOREIGN KEY FK_itempedido_infoadic_itempedido,
 CHANGE nao_movimentar_estoque nao_movimentar_estoque CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Não gerar a saída de estoque deste item ao emitir NF-e. (S)',
 CHANGE nao_gerar_financeiro nao_gerar_financeiro CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Não gerar conta a receber para este item. (S)';
ALTER TABLE dbintegracao.itempedido_infoadic
 ADD CONSTRAINT FK_itempedido_infoadic_itempedido FOREIGN KEY (Id_itempedido) REFERENCES dbintegracao.itempedido (id) ON UPDATE CASCADE ON DELETE CASCADE;

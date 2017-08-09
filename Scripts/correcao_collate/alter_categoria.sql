ALTER TABLE dbintegracao.categoria
 CHANGE conta_inativa conta_inativa CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs,
 CHANGE definida_pelo_usuario definida_pelo_usuario CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs,
 CHANGE conta_despesa conta_despesa CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs,
 CHANGE nao_exibir nao_exibir CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs,
 CHANGE conta_receita conta_receita CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs,
 CHANGE totalizadora totalizadora CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs,
 CHANGE transferencia transferencia CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs;

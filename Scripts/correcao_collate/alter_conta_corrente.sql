ALTER TABLE dbintegracao.conta_corrente
 CHANGE codigo_banco codigo_banco CHAR(3) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Código do Banco / Instituição Financeira',
 CHANGE tipo tipo CHAR(2) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Código da conta corrente no Omie.',
 CHANGE tipo_comunicacao tipo_comunicacao CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Tipo de comunicação ',
 CHANGE cSincrAnalitica cSincrAnalitica CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Sincronização Analítica para a Conta Corrente (Venda a Venda)',
 CHANGE cUtilPDV cUtilPDV CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Utiliza a Conta Corrente no OmiePDV';

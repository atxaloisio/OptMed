ALTER TABLE dbintegracao.cliente
 CHANGE estado estado CHAR(2) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Sigla do Estado',
 CHANGE pessoa_fisica pessoa_fisica CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Pessoa Física',
 CHANGE optante_simples_nacional optante_simples_nacional CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Indica se o Cliente / Fornecedor é Optante do Simples Nacional [S/N]',
 CHANGE bloqueado bloqueado CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Registro Bloqueado pela API',
 CHANGE importado_api importado_api CHAR(1) CHARACTER SET latin1 COLLATE latin1_general_cs COMMENT 'Gerado da API (S/N)';

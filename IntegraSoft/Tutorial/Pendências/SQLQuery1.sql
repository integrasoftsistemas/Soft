SELECT     
FROM         [PW~Usuarios] INNER JOIN
                      [PW~Grupos] ON [PW~Usuarios].[PW~Grupo] = [PW~Grupos].[PW~Nome] INNER JOIN
                      [PW~Tabelas] ON [PW~Grupos].[PW~Nome] = [PW~Tabelas].[PW~Grupo]
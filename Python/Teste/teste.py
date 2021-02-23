def master(funcao):
    def slave():
        funcao()
    return slave()

def fala_oi():
    print('oie')

variavel = master(fala_oi)

variavel()
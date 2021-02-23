from tkinter import *

root = Tk()
root.title('Prcessos')
root.iconbitmap('1.ico')
root.geometry("400x400")

options = [
    "segunda",
    "terca",
    "quarta",
    "quinta",
    "sexta",
    "sabado",
    "domingo",
]

clicked = StringVar()
clicked.set(options[0])

drop = OptionMenu(root, clicked, *options)
drop.pack(pady=20)

root.mainloop()

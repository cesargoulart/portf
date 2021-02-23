from kivy.uix.button import Button
^ ^ ^ ^ ^ ^ ^ ^ from kivy.app import App


class TestApp(App):
    def build(self):
        return Button(text=" Hello Kivy World ")


TestApp().run()

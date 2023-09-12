namespace eventbb
{
    delegate void Del();
    internal class Trezor
    {
            public event Del Utok; //tohle moc neřešit
            public bool Otevreni { get; set; } //vytvoří bool a rovnou nastaví gettery a settery
            public Trezor() {//bezparametrický objekt
                Otevreni = false;
            }

        //funkce, ke které budeme přiřazovat funkci v mainu
            public void otevirani()
            {
                Otevreni = true;
                Utok(); //přiřazovací event
            }
        
    }
}

namespace ReignSystem.Parameter
{
    public readonly struct OuterReignParameter
    {
        public readonly float comunication;
        public readonly float sympathy;
        public readonly float hatred;

        public OuterReignParameter(float comunication, float sympathy, float hatred)
        {
            this.comunication = comunication;
            this.sympathy = sympathy;
            this.hatred = hatred;
        }

        public OuterReignParameter WithComunication(float comunication) => new OuterReignParameter(comunication, sympathy, hatred);
        public OuterReignParameter WithSympathy(float sympathy) => new OuterReignParameter(comunication, sympathy, hatred);
        public OuterReignParameter WithHatred(float hatred) => new OuterReignParameter(comunication, sympathy, hatred);
    }
}
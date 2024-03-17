using ReignSystem.Modifier;
using ReignSystem.Parameter;
using ReignSystem.Parameter.Data;
using System.Collections.Generic;

namespace ReignSystem
{
    public readonly struct Reign : IModifiableReign,
        IModifiableReign<Reign>,
        IParametrizableReign<InnerReignParameters>,
        IParametrizableReign<OuterReignParameters<int>>,
        IParametrizableReign<Agenda>,
        IParametrizableReign<Population[]>,
        IParametrizableReign<Emigrations>,
        IParametrizableReign<Imigrations>
    {
        public readonly int ID { get; }
        public readonly InnerReignParameters InnerParameters { get; }
        public readonly OuterReignParameters<int> OuterParameters { get; }
        public readonly Agenda Agenda { get; }
        public readonly Population[] Populations { get; }
        public readonly Emigrations Emigrations { get; }
        public readonly Imigrations Imigrations { get; }

        InnerReignParameters IParametrizableReign<InnerReignParameters>.Parameter => InnerParameters;
        OuterReignParameters<int> IParametrizableReign<OuterReignParameters<int>>.Parameter => OuterParameters;
        Agenda IParametrizableReign<Agenda>.Parameter => Agenda;
        Population[] IParametrizableReign<Population[]>.Parameter => Populations;
        Emigrations IParametrizableReign<Emigrations>.Parameter => Emigrations;
        Imigrations IParametrizableReign<Imigrations>.Parameter => Imigrations;

        private readonly IEnumerable<IModifiableReign> _modifiableReigns;

        public Reign(int iD, InnerReignParameters innerParameters, OuterReignParameters<int> outerParameters, Agenda agenda, Population[] populations, Emigrations emigrations, Imigrations imigrations, IEnumerable<IModifiableReign> modifiableReigns)
        {
            ID = iD;
            InnerParameters = innerParameters;
            OuterParameters = outerParameters;
            Agenda = agenda;
            Populations = populations;
            Emigrations = emigrations;
            Imigrations = imigrations;
            _modifiableReigns = modifiableReigns;
        }

        public bool Accept<TReignModifier, TData, TReign>(TReignModifier reignModifier, out TReign reign) where TReignModifier : IReignModifier<TReign, TData>
        {
            reign = default;
            bool accepted = false;

            if (reignModifier is IReignModifier<TReign, Reign> modifier)
                accepted |= Accept(modifier, out reign);

            foreach (var modifiableReign in _modifiableReigns)
                accepted |= modifiableReign.Accept<TReignModifier, TData, TReign>(reignModifier, out reign);
            return accepted;
        }

        public bool Accept<TReignModifier, TReign>(TReignModifier reignModifier, out TReign reign) where TReignModifier : IReignModifier<TReign, Reign>
        {
            reign = reignModifier.Modify(this);
            return true;
        }

        public Reign WithID(int iD) =>
            new Reign(iD, InnerParameters, OuterParameters, Agenda, Populations, Emigrations, Imigrations, _modifiableReigns);

        public Reign WithInnerReignParameters(InnerReignParameters innerParameters) =>
            new Reign(ID, innerParameters, OuterParameters, Agenda, Populations, Emigrations, Imigrations, _modifiableReigns);

        public Reign WithOuterReignParameters(OuterReignParameters<int> outerParameters) =>
            new Reign(ID, InnerParameters, outerParameters, Agenda, Populations, Emigrations, Imigrations, _modifiableReigns);

        public Reign WithAgenda(Agenda agenda) =>
            new Reign(ID, InnerParameters, OuterParameters, agenda, Populations, Emigrations, Imigrations, _modifiableReigns);

        public Reign WithPopulations(Population[] populations) =>
            new Reign(ID, InnerParameters, OuterParameters, Agenda, populations, Emigrations, Imigrations, _modifiableReigns);

        public Reign WithEmigrations(Emigrations emigrations) =>
            new Reign(ID, InnerParameters, OuterParameters, Agenda, Populations, emigrations, Imigrations, _modifiableReigns);

        public Reign WithImigrations(Imigrations imigrations) =>
            new Reign(ID, InnerParameters, OuterParameters, Agenda, Populations, Emigrations, imigrations, _modifiableReigns);
    }
}
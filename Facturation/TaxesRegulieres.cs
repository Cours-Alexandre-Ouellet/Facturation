namespace Facturation
{
    /// <summary>
    /// Taxes appliquées de façon régulière sur les produits
    /// </summary>
    public class TaxesRegulieres : AbstractTaxes
    {
        public TaxesRegulieres(string codeTaxe, float tauxTaxeNationale, float tauxTaxeLocale) : 
            base(codeTaxe, tauxTaxeNationale, tauxTaxeLocale) { }

        public override AbstractTaxes Clone()
        {
            return new TaxesRegulieres(CodeTaxe, TauxTaxeNationale, TauxTaxeLocale);
        }
    }
}

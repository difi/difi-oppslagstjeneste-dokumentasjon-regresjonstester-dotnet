using System.IO;
using System.Security.Cryptography.X509Certificates;
using Difi.Oppslagstjeneste.Klient;
using Difi.Oppslagstjeneste.Klient.Domene.Entiteter.Enums;

namespace difi_ot_klient_v5.eksempler
{
    public class EksempelPaaKall
    {
        public void SettOppKlientkonfigurasjonFraThumbprint()
        {
            const string avsendersertifikatThumbprint = "fe14593dd66b2...";

            var konfigurasjon = new OppslagstjenesteKonfigurasjon(
                Miljø.FunksjoneltTestmiljøVerifikasjon1,
                avsendersertifikatThumbprint
            );
        }

        public void SettOppKlientkonfigurasjonFraFil()
        {
            const string avsendersertifikatSti = @"C:\Sti\Til\Sertifikat\Sertifikat.pfx";
            var sertifikat = new X509Certificate2(
                File.ReadAllBytes(avsendersertifikatSti),
                "Passord",
                X509KeyStorageFlags.Exportable
            );

            var konfigurasjon = new OppslagstjenesteKonfigurasjon(
                Miljø.FunksjoneltTestmiljøVerifikasjon1,
                sertifikat
            );
        }


        public void HentEndringer()
        {
            OppslagstjenesteKonfigurasjon konfigurasjon = null; //Som initiert tidligere

            var oppslagstjenesteKlient = new OppslagstjenesteKlient(konfigurasjon);

            const int fraEndringsNummer = 600;
            var endringer = oppslagstjenesteKlient.HentEndringer(fraEndringsNummer,
                Informasjonsbehov.Person,
                Informasjonsbehov.Kontaktinfo,
                Informasjonsbehov.Sertifikat,
                Informasjonsbehov.SikkerDigitalPost,
                Informasjonsbehov.VarslingsStatus
            );
        }

        public void HentPersoner()
        {
            OppslagstjenesteKonfigurasjon konfigurasjon = null; //Som initiert tidligere

            var oppslagstjenesteKlient = new OppslagstjenesteKlient(konfigurasjon);

            var personidentifikator = new[] {"08077000292"};
            var personer = oppslagstjenesteKlient.HentPersoner(personidentifikator,
                Informasjonsbehov.Kontaktinfo,
                Informasjonsbehov.Sertifikat,
                Informasjonsbehov.SikkerDigitalPost,
                Informasjonsbehov.VarslingsStatus
            );
        }

        public void HentPrintsertifikat()
        {
            OppslagstjenesteKonfigurasjon konfigurasjon = null; //Som initiert tidligere

            var oppslagstjenesteKlient = new OppslagstjenesteKlient(konfigurasjon);

            var printSertifikat = oppslagstjenesteKlient.HentPrintSertifikat();
        }
    }
}
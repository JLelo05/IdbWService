using LibDataHandler.Enums;
using LibDataHandler.Interfaces;
using LibDataHandler.Models;
using S7.Net;
using S7.Net.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LibDataHandler.Services
{
    public class ServiceDataHandeler
    {
        private bool _startSequence;
        public  DataBatchModel DataCollection { get; set; } = new DataBatchModel();

        public DataBatchModel BufferDataCollection { get; set; }
        public ServiceDataHandeler()
        {
            DataCollection.realData = new List<RealDataModel>() {
                new RealDataModel() { Name = "Dopravnik_RychlostVypoctena", Address ="ID760", TypeMeasure = MeasureType.Conveyor , IsChanged = true },
                new RealDataModel() { Name = "Odmasteni1_Teplota", Address ="ID600", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                new RealDataModel() { Name = "Odmasteni1_VentilOhrevPoz", Address ="ID624", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                new RealDataModel() { Name = "Odmasteni1_HladinaZad", Address ="ID612", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                new RealDataModel() { Name = "Odmasteni2_Hladina", Address ="ID638", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                new RealDataModel() { Name = "TopVoda_Hladina", Address ="ID702", TypeMeasure = MeasureType.Heatingwater, IsChanged = true },
                new RealDataModel() { Name = "TopVoda_TeplotaZad", Address ="ID698", TypeMeasure = MeasureType.Heatingwater, IsChanged = true },
                new RealDataModel() { Name = "Odmasteni2_HladinaZad", Address ="ID642", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                new RealDataModel() { Name = "CleanroomVZT_ServaPoz", Address ="ID738", TypeMeasure = MeasureType.Cleanroom_VZT, IsChanged = true },
                new RealDataModel() { Name = "Pec_Teplota", Address ="ID744", TypeMeasure = MeasureType.Oven, IsChanged = true },
                new RealDataModel() { Name = "Oplach3_VodivostZad", Address ="ID674", TypeMeasure = MeasureType.Pretreatment_rinse, IsChanged = true },
                 new RealDataModel() { Name = "CleanroomVZT_TeplotaZad", Address ="ID734", TypeMeasure = MeasureType.Cleanroom_VZT, IsChanged = true },
                 new RealDataModel() { Name = "Pec_HorakVykon", Address ="ID752", TypeMeasure = MeasureType.Oven, IsChanged = true },
                 new RealDataModel() { Name = "Oplach3_Vodivost", Address ="ID670", TypeMeasure = MeasureType.Pretreatment_rinse, IsChanged = true },
                 new RealDataModel() { Name = "TopVoda_HladinaZad", Address ="ID706", TypeMeasure = MeasureType.Heatingwater, IsChanged = true },
                 new RealDataModel() { Name = "Odmasteni1_Vodivost", Address ="ID616", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                 new RealDataModel() { Name = "Pasivace_PH", Address ="ID660", TypeMeasure = MeasureType.Pretreatment_passivation, IsChanged = true },
                 new RealDataModel() { Name = "CleanroomVZT_Teplota", Address ="ID730", TypeMeasure = MeasureType.Cleanroom_VZT, IsChanged = true },
                 new RealDataModel() { Name = "Odmasteni2_Vodivost", Address ="ID646", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                 new RealDataModel() { Name = "PrivodVZT_BypassPoloha", Address ="ID688", TypeMeasure = MeasureType.Supplyair_VZT, IsChanged = true },
                 new RealDataModel() { Name = "Pec_TeplotaZad", Address ="ID748", TypeMeasure = MeasureType.Oven, IsChanged = true },
                 new RealDataModel() { Name = "Suska_HorakVykon", Address ="ID724", TypeMeasure = MeasureType.Drying, IsChanged = true },
                 new RealDataModel() { Name = "Suska_TeplotaZad", Address ="ID720", TypeMeasure = MeasureType.Drying, IsChanged = true },
                 new RealDataModel() { Name = "Odmasteni2_Teplota", Address ="ID630", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                 new RealDataModel() { Name = "Dopravnik_RychlostZadana", Address ="ID764", TypeMeasure = MeasureType.Conveyor, IsChanged = true },
                 new RealDataModel() { Name = "TopVoda_Teplota", Address ="ID694", TypeMeasure = MeasureType.Heatingwater, IsChanged = true },
                 new RealDataModel() { Name = "PrivodVZT_Teplota", Address ="ID680", TypeMeasure = MeasureType.Supplyair_VZT, IsChanged = true },
                 new RealDataModel() { Name = "PrivodVZT_TeplotaZad", Address ="ID684", TypeMeasure = MeasureType.Supplyair_VZT, IsChanged = true },
                 new RealDataModel() { Name = "Suska_Teplota", Address ="ID716", TypeMeasure = MeasureType.Drying, IsChanged = true },
                 new RealDataModel() { Name = "Pasivace_PHZad", Address ="ID664", TypeMeasure = MeasureType.Pretreatment_passivation, IsChanged = true },
                 new RealDataModel() { Name = "Odmasteni2_TeplotaZad", Address ="ID634", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                 new RealDataModel() { Name = "Odmasteni2_VentilOhrevPoz", Address ="ID654", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                 new RealDataModel() { Name = "Odmasteni2_VodivostZad", Address ="ID650", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                 new RealDataModel() { Name = "Odmasteni1_VodivostZad", Address ="ID620", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                 new RealDataModel() { Name = "TopVoda_HorakVykon", Address ="ID710", TypeMeasure = MeasureType.Heatingwater, IsChanged = true },
                 new RealDataModel() { Name = "Odmasteni1_Hladina", Address ="ID608", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                 new RealDataModel() { Name = "Odmasteni1_TeplotaZad", Address ="ID604", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                };

            DataCollection.boolData = new List<BoolDataModel>() {

                        new BoolDataModel() { Name = "Pec_VentilatorOdsavaniChod", Address ="I757.4", TypeMeasure = MeasureType.Oven, IsChanged = true },
                        new BoolDataModel() { Name = "Oplach2_CerpPorucha", Address ="I659.3", TypeMeasure = MeasureType.Pretreatment_rinse, IsChanged = true },
                        new BoolDataModel() { Name = "TopVoda_CerpCirkulacePorucha", Address ="I714.1", TypeMeasure = MeasureType.Heatingwater, IsChanged = true },
                        new BoolDataModel() { Name = "HeartBeat_Ekol_IN", Address ="I772.0", TypeMeasure = MeasureType.None, IsChanged = true },
                        new BoolDataModel() { Name = "Pec_VentilatorVystup2Chod", Address ="I757.2", TypeMeasure = MeasureType.Oven, IsChanged = true },
                        new BoolDataModel() { Name = "TopVoda_VentilPlneniOte", Address ="I714.5", TypeMeasure = MeasureType.Heatingwater, IsChanged = true },
                        new BoolDataModel() { Name = "Tunel_VentilatorPrivodniChod", Address ="I758.0", TypeMeasure = MeasureType.Tunel, IsChanged = true },
                        new BoolDataModel() { Name = "CleanroomVZT_VentilatorChod", Address ="I742.0", TypeMeasure = MeasureType.Cleanroom_VZT, IsChanged = true },
                        new BoolDataModel() { Name = "Suska_VentilatorCirk1Porucha", Address ="I728.1", TypeMeasure = MeasureType.Drying, IsChanged = true },
                        new BoolDataModel() { Name = "Oplach1_CerpPorucha", Address ="I659.1", TypeMeasure = MeasureType.Pretreatment_rinse, IsChanged = true },
                        new BoolDataModel() { Name = "Dopravnik_KabinaNovNouzStop", Address ="I769.0", TypeMeasure = MeasureType.Conveyor, IsChanged = true },
                        new BoolDataModel() { Name = "Oplach3_VentilPostrikOte", Address ="I678.2", TypeMeasure = MeasureType.Pretreatment_rinse, IsChanged = true },
                        new BoolDataModel() { Name = "Suska_VentilatorVystupPorucha", Address ="I728.7", TypeMeasure = MeasureType.Drying, IsChanged = true },
                        new BoolDataModel() { Name = "RezimDoprava_Start", Address ="I771.4", TypeMeasure = MeasureType.Conveyor, IsChanged = true },
                        new BoolDataModel() { Name = "Pec_VentilatorCirk1Porucha", Address ="I756.1", TypeMeasure = MeasureType.Oven, IsChanged = true },
                        new BoolDataModel() { Name = "Odmasteni1_CerpDavkovani1Chod", Address ="I628.5", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true },
                        new BoolDataModel() { Name = "Dopravnik_PrivodVZTStop", Address ="I770.5", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Suska_VentilatorCirk2Chod", Address ="I728.2", TypeMeasure = MeasureType.Drying , IsChanged = true },
                        new BoolDataModel() { Name = "Dopravnik_Oplach2Stop", Address ="I771.1", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Tunel_VentilatorOdsavaniPorucha", Address ="I758.3", TypeMeasure = MeasureType.Tunel , IsChanged = true },
                        new BoolDataModel() { Name = "TopVoda_CerpCirkulaceChod", Address ="I714.0", TypeMeasure = MeasureType.Heatingwater , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_NouzStopPPNov", Address ="I769.1", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_MazaniPorucha", Address ="I768.3", TypeMeasure = MeasureType.Conveyor   , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni2_CerpCirkulacePorucha", Address ="I658.1", TypeMeasure = MeasureType.Pretreatment_degreasing, IsChanged = true},
                        new BoolDataModel() { Name = "Oplach3_CerpChod", Address ="I678.0", TypeMeasure = MeasureType.Pretreatment_rinse , IsChanged = true},
                        new BoolDataModel() { Name = "CleanroomVZT_ChladJednotkaChod", Address ="I742.2", TypeMeasure = MeasureType.Cleanroom_VZT , IsChanged = true},
                        new BoolDataModel() { Name = "Pec_VentilatorCirk1Chod", Address ="I756.0", TypeMeasure = MeasureType.Oven , IsChanged = true},
                        new BoolDataModel() { Name = "RezimDoprava_Stop", Address ="I771.5", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_Oplach1Stop", Address ="I771.0", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_BezpRelePorucha", Address ="I769.5", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_KabinaNovStopDopravy", Address ="I769.4", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_NizkaRychlostPorucha", Address ="I770.1", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Tunel_VentilatorPrivodniPorucha", Address ="I758.1", TypeMeasure = MeasureType.Tunel  , IsChanged = true},
                        new BoolDataModel() { Name = "Pec_VentilatorCirk2Chod", Address ="I756.2", TypeMeasure = MeasureType.Oven , IsChanged = true},
                        new BoolDataModel() { Name = "Oplach2_CerpChod", Address ="I659.2", TypeMeasure = MeasureType.Pretreatment_rinse , IsChanged = true},
                        new BoolDataModel() { Name = "Suska_HorakPorucha", Address ="I729.1", TypeMeasure = MeasureType.Drying , IsChanged = true},
                        new BoolDataModel() { Name = "PrivodVZT_VentilatorOdsavaciChod", Address ="I692.0", TypeMeasure = MeasureType.Cleanroom_VZT , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni1_CerpOdmasteniChod", Address ="I628.2", TypeMeasure = MeasureType.Pretreatment_degreasing , IsChanged = true},
                        new BoolDataModel() { Name = "Pec_VentilatorVstup1Porucha", Address ="I756.5", TypeMeasure = MeasureType.Oven , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni1_CerpCirkulacePorucha", Address ="I628.1", TypeMeasure = MeasureType.Pretreatment_degreasing , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni1_CerpDavkovani2Chod", Address ="I628.6", TypeMeasure = MeasureType.Pretreatment_degreasing , IsChanged = true},
                        new BoolDataModel() { Name = "PrivodVZT_VentilatorPrivodniChod", Address ="I692.2", TypeMeasure = MeasureType.Cleanroom_VZT , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni1_VentilDopousteniOte", Address ="I628.4", TypeMeasure = MeasureType.Pretreatment_degreasing , IsChanged = true},
                        new BoolDataModel() { Name = "PrivodVZT_VentilatorOdsavaciPorucha", Address ="I692.1", TypeMeasure = MeasureType.Cleanroom_VZT , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni2_CerpOdmasteniPorucha", Address ="I658.3", TypeMeasure = MeasureType.Pretreatment_degreasing , IsChanged = true},
                        new BoolDataModel() { Name = "RezimDoprava_Servis", Address ="I771.6", TypeMeasure = MeasureType.None , IsChanged = true},
                        new BoolDataModel() { Name = "ZasNadrz12_MaxHladina", Address ="I693.1", TypeMeasure = MeasureType.Tank , IsChanged = true},
                        new BoolDataModel() { Name = "RezimTechnologie_Stop", Address ="I759.1", TypeMeasure = MeasureType.None , IsChanged = true},
                        new BoolDataModel() { Name = "Pec_VentilatorVstup2Chod", Address ="I756.6", TypeMeasure = MeasureType.Oven , IsChanged = true},
                        new BoolDataModel() { Name = "RezimDoprava_Odstaveni", Address ="I771.7", TypeMeasure = MeasureType.None , IsChanged = true},
                        new BoolDataModel() { Name = "TopVoda_HorakPorucha", Address ="I714.3", TypeMeasure = MeasureType.Tunel , IsChanged = true},
                        new BoolDataModel() { Name = "Pec_VentilatorVystup2Porucha", Address ="I757.3", TypeMeasure = MeasureType.Tunel , IsChanged = true},
                        new BoolDataModel() { Name = "Suska_HorakChod", Address ="I729.0", TypeMeasure = MeasureType.Tunel , IsChanged = true},
                        new BoolDataModel() { Name = "Pasivace_CerpPasivacePorucha", Address ="I668.1", TypeMeasure = MeasureType.Tunel , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_PasivaceStop", Address ="I771.2", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni1_CerpOdmasteniPorucha", Address ="I628.3", TypeMeasure = MeasureType.Pretreatment_degreasing , IsChanged = true},
                        new BoolDataModel() { Name = "Pec_VentilatorVystup1Porucha", Address ="I757.1", TypeMeasure = MeasureType.Tunel , IsChanged = true},
                        new BoolDataModel() { Name = "Pasivace_CerpPasivaceChod", Address ="I668.0", TypeMeasure = MeasureType.Tunel , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_NouzStopPS", Address ="I768.5", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_PohonVzad", Address ="I772.1", TypeMeasure = MeasureType.Conveyor   , IsChanged = true },
                        new BoolDataModel() { Name = "Oplach3_VentilVodaOte", Address ="I678.3", TypeMeasure = MeasureType.Tunel , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_Odmasteni1Stop", Address ="I770.6", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni2_VentilDopousteniOte", Address ="I658.4", TypeMeasure = MeasureType.Pretreatment_degreasing     , IsChanged = true},
                        new BoolDataModel() { Name = "RezimTechnologie_Start", Address ="I759.0", TypeMeasure = MeasureType.None , IsChanged = true},
                        new BoolDataModel() { Name = "Pec_VentilatorCirk2Porucha", Address ="I756.3", TypeMeasure = MeasureType.Oven , IsChanged = true},
                        new BoolDataModel() { Name = "PrivodVZT_VentilatorPrivodniPorucha", Address ="I692.3", TypeMeasure = MeasureType.Supplyair_VZT , IsChanged = true},
                        new BoolDataModel() { Name = "Tunel_VentilatorOdsavaniChod", Address ="I758.2", TypeMeasure = MeasureType.Tunel , IsChanged = true},
                        new BoolDataModel() { Name = "RezimTechnologie_Pauza", Address ="I759.5", TypeMeasure = MeasureType.None , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_MazaniChod", Address ="I768.2", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Pec_VentilatorVystup1Chod", Address ="I757.0", TypeMeasure = MeasureType.Oven , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_NouzStopRM1", Address ="I768.4", TypeMeasure = MeasureType.Conveyor     , IsChanged = true},
                        new BoolDataModel() { Name = "TopVoda_VentilatorHorakChod", Address ="I714.4", TypeMeasure = MeasureType.Heatingwater , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_NouzStopPPPuv", Address ="I768.6", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "AkuNadrz11_MaxHladina", Address ="I693.0", TypeMeasure = MeasureType.Tank , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni2_CerpOdmasteniChod", Address ="I658.2", TypeMeasure = MeasureType.Pretreatment_degreasing , IsChanged = true},
                        new BoolDataModel() { Name = "Pasivace_CerpDavkovaniChod", Address ="I668.2", TypeMeasure = MeasureType.Pretreatment_passivation , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_NapinaniPorucha", Address ="I769.7", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Oplach2_VentilOte", Address ="I659.4", TypeMeasure = MeasureType.Pretreatment_rinse , IsChanged = true},
                        new BoolDataModel() { Name = "Suska_VentilatorVystupChod", Address ="I728.6", TypeMeasure = MeasureType.Drying  , IsChanged = true},
                        new BoolDataModel() { Name = "Pec_VentilatorVstup1Chod", Address ="I756.4", TypeMeasure = MeasureType.Oven , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_Start_Buttons_Imp", Address ="I772.2", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Suska_VentilatorVstupPorucha", Address ="I728.5", TypeMeasure = MeasureType.Drying , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni2_CerpDavkovani2Chod", Address ="I658.6", TypeMeasure = MeasureType.Pretreatment_degreasing , IsChanged = true},
                        new BoolDataModel() { Name = "CleanroomVZT_ChladJednotkaPorucha", Address ="I742.3", TypeMeasure = MeasureType.Cleanroom_VZT , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_TopnaVodaStop", Address ="I770.4", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "CleanroomVZT_VentilatorPorucha", Address ="I742.1", TypeMeasure = MeasureType.Cleanroom_VZT , IsChanged = true},
                        new BoolDataModel() { Name = "Pec_VentilatorVstup2Porucha", Address ="I756.7", TypeMeasure = MeasureType.Oven , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni2_CerpCirkulaceChod", Address ="I658.0", TypeMeasure = MeasureType.Pretreatment_degreasing , IsChanged = true},
                        new BoolDataModel() { Name = "Oplach1_CerpChod", Address ="I659.0", TypeMeasure = MeasureType.Pretreatment_rinse , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_TlacitkoStop", Address ="I770.2", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Suska_VentilatorCirk2Porucha", Address ="I728.3", TypeMeasure = MeasureType.Tunel , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_Odmasteni2Stop", Address ="I770.7", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni2_CerpDavkovani1Chod", Address ="I658.5", TypeMeasure = MeasureType.Pretreatment_degreasing , IsChanged = true},
                        new BoolDataModel() { Name = "Pec_VentilatorOdsavaniPorucha", Address ="I757.5", TypeMeasure = MeasureType.Tunel , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_NouzStopNavSves", Address ="I769.2", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_Oplach3Stop", Address ="I771.3", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_PohonChod", Address ="I768.0", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_PrujezdPorucha", Address ="I770.0", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "RezimTechnologie_Zatop", Address ="I759.3", TypeMeasure = MeasureType.None , IsChanged = true},
                        new BoolDataModel() { Name = "ZasNadrz13_MaxHladina", Address ="I693.2", TypeMeasure = MeasureType.Tank , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_KabinaPuvNouzStop", Address ="I768.7", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "RezimTechnologie_Odstaveni", Address ="I759.4", TypeMeasure = MeasureType.None , IsChanged = true},
                        new BoolDataModel() { Name = "RezimTechnologie_Servis", Address ="I759.2", TypeMeasure = MeasureType.None , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_PauzaProvozu", Address ="I770.3", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Suska_VentilatorVstupChod", Address ="I728.4", TypeMeasure = MeasureType.Drying , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_KabinaPuvStopDopravy", Address ="I769.3", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Suska_VentilatorCirk1Chod", Address ="I728.0", TypeMeasure = MeasureType.Drying , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_PohonPorucha", Address ="I768.1", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Oplach3_CerpPorucha", Address ="I678.1", TypeMeasure = MeasureType.Pretreatment_rinse , IsChanged = true},
                        new BoolDataModel() { Name = "Dopravnik_TlakVzduchuPorucha", Address ="I769.6", TypeMeasure = MeasureType.Conveyor , IsChanged = true},
                        new BoolDataModel() { Name = "Odmasteni1_CerpCirkulaceChod", Address ="I628.0", TypeMeasure = MeasureType.Pretreatment_degreasing , IsChanged = true},
                        new BoolDataModel() { Name = "TopVoda_HorakChod", Address ="I714.2", TypeMeasure = MeasureType.Heatingwater , IsChanged = true},



            };
            _startSequence = true;
        }
        public DataBatchModel GetPLCValues(Plc plc)
        {
            BufferDataCollection = new DataBatchModel(DataCollection);
            try
            {
                foreach (var item in DataCollection.realData)
                {
                    item.Value = ((uint)plc.Read(item.Address)).ConvertToFloat();
                }
                foreach (var item in DataCollection.boolData)
                {
                    item.Value = ((bool)plc.Read(item.Address));
                }
                DataCollection.DataRecieved = true;
                if (!_startSequence)
                {
                    CompareData(DataCollection, BufferDataCollection);
                }
                _startSequence = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); 
                DataCollection.DataRecieved= false;
            }
            return DataCollection;
        }

        private void CompareData(DataBatchModel newData, DataBatchModel oldData)
        {
            if (newData.realData != null && !newData.realData.SequenceEqual(oldData.realData))
            {
                int i = 0;
                foreach (var newItem in newData.realData)
                {
                    if (newItem.Value.Equals((oldData.realData[i].Value)))
                    {
                        newItem.IsChanged = false;
                    } else newItem.IsChanged = true;
                    i++;
                }
            }
            if (newData.boolData != null)
            {
                int i = 0;
                foreach (var newItem in newData.boolData)
                {
                    if (newItem.Value.Equals((oldData.boolData[i].Value)))
                    {
                        newItem.IsChanged = false;
                    } else newItem.IsChanged = true;
                    i++;
                }
            }

        }

    }
}

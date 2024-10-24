using AutoMapper;
using WebAppGedQuestionnaire.Controllers.Dto.Requetes;
using WebAppGedQuestionnaire.Controllers.Dto.Resources;
using WebAppGedQuestionnaire.Models;


namespace WebAppGedQuestionnaire.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {

            #region ------ // (domaine to ressource) // -----           
                    CreateMap<Employe, EmployeResDto>();

   
            #endregion

            #region ----- // ( ressource to domaine ) // -----
                    CreateMap<CocherTamponRqDto, CocherTampon>();
                    CreateMap<CocherRqDto, Cocher>();

                    CreateMap<DroitAccesReqDto, DroitAcces>();        

                    CreateMap<Utilisateur, UtilisateurReqDto>()
                        .ForMember(o => o.Nom, opt => opt.MapFrom(src => src.Nom))
                        .ForMember(o => o.Prenoms, opt => opt.MapFrom(src => src.Prenoms))
                        .ForMember(v => v.DroitAccesId, opt => opt.MapFrom(src => src.DroitAcces.DroitAccesId))
                        .ForMember(u => u.Libelle, opt => opt.MapFrom(src => src.DroitAcces.Libelle))
                        .ForMember(o => o.Level, opt => opt.MapFrom(src => src.DroitAcces.Level))
                        .ForMember(n => n.UserEstActif, opt => opt.MapFrom(src => src.UserEstActif))
                        .ForMember(m => m.Mail, opt => opt.MapFrom(src => src.Mail))
                   .ReverseMap();


            #endregion
        }

    }
}

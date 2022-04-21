using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPILayer
{
    public static class ServiceInjector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<IAboutService, AboutManager>().AddTransient<IAboutDal, EFAboutRepository>();
            services.AddTransient<ICategoryService, CategoryManager>().AddTransient<ICategoryDal, EFCategoryRepository>();
            services.AddTransient<IContactService, ContactManager>().AddTransient<IContactDal, EFContactRepository>();
            services.AddTransient<ICustomerService, CustomerManager>().AddTransient<ICustomerDal, EFCustomerRepository>();
            services.AddTransient<ICVDocumentService, CVDocumentManager>().AddTransient<ICVDocumentDal, EFCVDocumentRepository>();
            services.AddTransient<IEducationService, EducationManager>().AddTransient<IEducationDal, EFEducationRepository>();
            services.AddTransient<IExperienceService, ExperienceManager>().AddTransient<IExperienceDal, EFExperienceRepository>();
            services.AddTransient<IOtherKnowledgeService, OtherKnowledgeManager>().AddTransient<IOtherKnowledgeDal, EFOtherKnowledgeRepository>();
            services.AddTransient<IProfilService, ProfilManager>().AddTransient<IProfilDal, EFProfilRepository>();
            services.AddTransient<IProjectService, ProjectManager>().AddTransient<IProjectDal, EFProjectRepository>();
            services.AddTransient<ISkillService, SkillManager>().AddTransient<ISkillDal, EFSkillRepository>();
            services.AddTransient<ISosialService, SosialManager>().AddTransient<ISosialDal, EFSosialRepository>();
        }
    }
}

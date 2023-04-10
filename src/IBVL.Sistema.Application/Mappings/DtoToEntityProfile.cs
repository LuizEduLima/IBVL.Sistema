
using AutoMapper;
using IBVL.Sistema.Application.Dtos;
using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Application.Mappings
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            CreateMap<MembroDto, Membro>()
                .ForMember(model => model.RG.Numero, dto => dto.MapFrom(r => r.RG))
                .ForMember(model => model.CPF.Numero, dto => dto.MapFrom(c => c.CPF))
                .ForMember(model => model.Situacao, dto => dto.MapFrom(c => c.Situacao))
                .ForMember(model => model.Nacionalidade, dto => dto.MapFrom(c => c.Nacionalidade))
                .ForMember(model => model.Naturalidade, dto => dto.MapFrom(c => c.Naturalidade))
                .ForMember(model => model.DataNascimento, dto => dto.MapFrom(c => c.DataNascimento))
                .ForMember(model => model.Apelido, dto => dto.MapFrom(c => c.Apelido))
                .ForMember(model => model.Sexo, dto => dto.MapFrom(c => c.Sexo))
                .ForMember(model => model.Apelido, dto => dto.MapFrom(c => c.Apelido))
                .ForMember(model => model.EhBatizado, dto => dto.MapFrom(c => c.EhBatizado))
                .ForMember(model => model.EhDizimista, dto => dto.MapFrom(c => c.EhDizimista))
                .ForMember(model => model.Endereco.Logradouro, dto => dto.MapFrom(c => c.Endereco.Logradouro))
                .ForMember(model => model.Endereco.Numero, dto => dto.MapFrom(c => c.Nacionalidade))
                .ForMember(model => model.Endereco.CEP, dto => dto.MapFrom(c => c.Endereco.CEP))
                .ForMember(model => model.Endereco.Bairro, dto => dto.MapFrom(c => c.Endereco.Bairro))
                .ForMember(model => model.Endereco.Cidade, dto => dto.MapFrom(c => c.Endereco.Cidade))
                .ForMember(model => model.Endereco.Estado, dto => dto.MapFrom(c => c.Endereco.Estado))
                .ForMember(model => model.Usuario.Login, dto => dto.MapFrom(c => c.Email)).ReverseMap();

            CreateMap<CargoPastoralDto, CargoPastoral>().ReverseMap();
            CreateMap<EnderecoDto, EnderecoDto>().ReverseMap();
            CreateMap<ProfissaoDto, ProfissaoDto>().ReverseMap();
            CreateMap<TelefoneDto, TelefoneDto>().ReverseMap();
            CreateMap<UsuarioDto, UsuarioDto>().ReverseMap();
            

        }
    }
}

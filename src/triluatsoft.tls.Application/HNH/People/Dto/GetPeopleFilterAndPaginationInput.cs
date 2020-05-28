using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace triluatsoft.tls.HNH.People.Dto
{
    public class GetPeopleFilterAndPaginationInput : IPagedResultRequest
    {
        public string Filter { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        [Range(1, AppConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }
    }
}

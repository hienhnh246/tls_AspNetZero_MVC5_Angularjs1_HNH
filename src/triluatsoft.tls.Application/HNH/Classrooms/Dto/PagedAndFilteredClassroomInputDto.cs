﻿using Abp.Application.Services.Dto;
using System.ComponentModel.DataAnnotations;

namespace triluatsoft.tls.HNH.Classrooms.Dto
{
    public class PagedAndFilteredClassroomInputDto : IPagedResultRequest
    {
        [Range(1, AppConsts.MaxPageSize)]
        public int MaxResultCount { get; set; }

        [Range(0, int.MaxValue)]
        public int SkipCount { get; set; }

        public string Filter { get; set; }

        public PagedAndFilteredClassroomInputDto()
        {
            MaxResultCount = AppConsts.DefaultPageSize;
        }
    }
}

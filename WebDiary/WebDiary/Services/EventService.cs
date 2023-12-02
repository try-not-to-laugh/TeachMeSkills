﻿using AutoMapper;
using Data.Models;
using WebDiary.Models;
using WebDiary.Services.Interfaces;

namespace WebDiary.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly WebDiaryContext _webDiaryContext;
        public EventService(WebDiaryContext webDiaryContext, IMapper mapper)
        {
            _webDiaryContext = webDiaryContext;
            _mapper = mapper;
        }

        public List<EventDTO> LoadEvents()
        {
            var objs = _webDiaryContext.Events.ToList();
            var objsDTO = _mapper.Map<List<EventDTO>>(objs);
            return objsDTO;
        }

        public EventDTO GetEvent(Guid eventId)
        {
            var obj = _webDiaryContext.Events.FirstOrDefault(p => p.Id == eventId);
            var objDTO = _mapper.Map<EventDTO>(obj);
            return objDTO;
        }

        public void CreateEvent(EventDTO eventModel)
        {
            //event validation
            var obj = _mapper.Map<Event>(eventModel);
            _webDiaryContext.Events.Add(obj);
            _webDiaryContext.SaveChanges();
        }

        public void UpdateEvent(EventDTO eventModel)
        {
            var obj = _mapper.Map<Event>(eventModel);
            _webDiaryContext.Events.Update(obj);
            _webDiaryContext.SaveChanges();
        }

        public void DeleteEvent(Guid eventId)
        {
            var obj = _webDiaryContext.Events.FirstOrDefault(p => p.Id == eventId);
            if (obj != null)
            {
                _webDiaryContext.Events.Remove(obj);
                _webDiaryContext.SaveChanges();
            }

        }
    }
}
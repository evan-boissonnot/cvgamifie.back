﻿using Data.Model;
using System.Linq;
using Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace TrainerAPI.Business
{
    public class TrainingCourseStudentBusiness
    {
        private readonly DefaultContext _defaultContext;

        public TrainingCourseStudentBusiness(DefaultContext defaultContext)
        {
            _defaultContext = defaultContext;
        }

        public TrainingCourseStudent Create(TrainingCourseStudent trainingCourse)
        {
            var addResult = _defaultContext.TrainingCourseStudents.Add(trainingCourse);
            int saveResult;
            try
            {
                saveResult = _defaultContext.SaveChanges();
            }
            catch
            {
                return null;
            }
            return saveResult == 1 ? addResult.Entity : null;
        }

        public TrainingCourseStudent Read(int id)
        {
            var trainingCourseStudent = _defaultContext.TrainingCourseStudents.AsNoTracking().FirstOrDefault(x => x.Id == id);
            return trainingCourseStudent;
        }

        public IEnumerable<TrainingCourseStudent> List()
        {
            var trainingCourseStudents = _defaultContext.TrainingCourseStudents.AsNoTracking();
            return trainingCourseStudents;
        }

        public bool Update(TrainingCourseStudent trainingCourseStudentToUpdate)
        {
            var trainingCourseStudent = _defaultContext.TrainingCourseStudents.AsNoTracking().FirstOrDefault(x => x.Id == trainingCourseStudentToUpdate.Id);
            if (trainingCourseStudent == null)
                return false;

            _defaultContext.TrainingCourseStudents.Update(trainingCourseStudentToUpdate);
            var saveResult = _defaultContext.SaveChanges();
            return saveResult == 1;
        }

        public bool Delete(int id)
        {
            var trainingCourseStudent = _defaultContext.TrainingCourseStudents.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (trainingCourseStudent == null)
                return false;

            _defaultContext.TrainingCourseStudents.Remove(trainingCourseStudent);
            var saveResult = _defaultContext.SaveChanges();
            return saveResult == 1;
        }
    }
}
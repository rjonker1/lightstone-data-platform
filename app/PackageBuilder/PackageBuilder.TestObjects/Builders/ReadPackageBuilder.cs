﻿using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.Industries.Read;
using PackageBuilder.Domain.Entities.Packages.Read;
using PackageBuilder.Domain.Entities.States.Read;

namespace PackageBuilder.TestObjects.Builders
{
    public class ReadPackageBuilder
    {
        private Guid _id;
        private string _name;
        private string _description;
        public State _state;
        private int _version;
        private decimal _displayVersion;
        private string _owner;
        private DateTime _createdDate;
        private DateTime? _editedDate;
        private PackageEventType _packageEventType;
        private IEnumerable<Industry> _industries;
        public Package Build()
        {
            return new Package(_id, _name, _description, _state, _version, _displayVersion, _owner, _createdDate, _editedDate, _packageEventType, _industries);
        }

        public ReadPackageBuilder With(Guid id)
        {
            _id = id;
            return this;
        }

        public ReadPackageBuilder With(string name)
        {
            _name = name;
            _description = name;
            return this;
        }

        public ReadPackageBuilder With(State state)
        {
            _state = state;
            return this;
        }

        public ReadPackageBuilder With(int version)
        {
            _version = version;
            return this;
        }

        public ReadPackageBuilder With(decimal displayVersion)
        {
            _displayVersion = displayVersion;
            return this;
        }

        public ReadPackageBuilder With(DateTime createdDate)
        {
            _createdDate = createdDate;
            _editedDate = createdDate;
            return this;
        }

        public ReadPackageBuilder With(params Industry[] industries)
        {
            _industries = industries;
            return this;
        }

        public ReadPackageBuilder With(PackageEventType packageEventType)
        {
            _packageEventType = packageEventType;
            return this;
        }
    }
}
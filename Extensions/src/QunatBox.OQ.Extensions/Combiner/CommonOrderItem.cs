﻿using QuantBox.OQ.Extensions.OrderText;
using SmartQuant.Execution;
using SmartQuant.FIX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantBox.OQ.Extensions.Combiner
{
    public class CommonOrderItem : GenericOrderItem
    {
        public MultiOrderLeg Leg = null;

        public override void Init(TextCommon t)
        {
            base.Init(t);
            Leg = null;
        }

        public override void Add(SingleOrder order, TextCommon t)
        {
            Leg = new MultiOrderLeg { Order = order, OpenClose = t.OpenClose };
        }

        public override IEnumerable<MultiOrderLeg> GetLegs()
        {
            return new List<MultiOrderLeg>() { Leg };
        }

        public override int GetLegNum()
        {
            return 1;
        }

        public override MultiOrderLeg GetLeg(Side side,string instrument)
        {
            return Leg;
        }

        public override bool IsCreated()
        {
            return Leg != null;
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallongeCSharp
{
    public class ChallongeMatch
    {
        public object attachment_count { get; set; }
        public string created_at { get; set; }
        public object group_id { get; set; }
        public bool has_attachment { get; set; }
        public int id { get; set; }
        public string identifier { get; set; }
        public object location { get; set; }
        public object loser_id { get; set; }
        public int player1_id { get; set; }
        public bool player1_is_prereq_match_loser { get; set; }
        public object player1_prereq_match_id { get; set; }
        public object player1_votes { get; set; }
        public int player2_id { get; set; }
        public bool player2_is_prereq_match_loser { get; set; }
        public object player2_prereq_match_id { get; set; }
        public object player2_votes { get; set; }
        public int round { get; set; }
        public object scheduled_time { get; set; }
        public string started_at { get; set; }
        public string state { get; set; }
        public int tournament_id { get; set; }
        public object underway_at { get; set; }
        public string updated_at { get; set; }
        public object winner_id { get; set; }
        public string prerequisite_match_ids_csv { get; set; }
        public string scores_csv { get; set; }
        public List<string> errors { get; set; }
    }
}

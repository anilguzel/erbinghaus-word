package models

import (
	"time"
)

type Word struct {
	id    string  `bson:"_id,omitempty"`
	name string  `bson:"name,omitempty"`
	created time.Time  `bson:"created,omitempty"`
	updated time.Time  `bson:"updated,omitempty"`
	day int  `bson:"day,omitempty"`
	is_daily_done bool  `bson:"is_daily_done,omitempty"`
	Is_done bool  `bson:"is_done,omitempty"`
	sentences []Sentence `bson:"sentences,omitempty"`
 }
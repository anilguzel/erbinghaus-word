package models

import (
	"time"
)

type Sentence struct {
	id    string  `bson:"_id,omitempty"`
	text string  `bson:"text,omitempty"`
	created time.Time  `bson:"created,omitempty"`
	updated time.Time  `bson:"updated,omitempty"`
 }
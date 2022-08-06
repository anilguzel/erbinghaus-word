package models

import (
	"go.mongodb.org/mongo-driver/bson/primitive"
)

type Card struct {
	Id     primitive.ObjectID `bson:"_id,omitempty"`
	Words  []Word             `bson:"word,omitempty"`
}

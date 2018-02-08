using LAB1_UserCollections.Model;
using System;
using System.Collections;
using System.Linq;

namespace LAB1_UserCollections
{
    public class CitizenCollection : ICollection
    {
        #region Members

        private Citizen[] mCitizens = new Citizen[CitizenCollectionConstants.SizeOfInitArray];
        private int mLastPensionerPosition;

        #endregion

        #region Properties

        public int Count { get; private set; }

        public object SyncRoot => null;

        public bool IsSynchronized => false;

        public Citizen this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                return mCitizens[index];
            }
        }

        #endregion

        public CitizenCollection()
        {
            Clear();
        }

        #region Public methods

        public int Add(Citizen citizen)
        {
            if (mCitizens.Contains(citizen))
                throw new ArgumentException("citizen is already exist");

            if (++Count >= mCitizens.Length)
                ResizeArray();

            return citizen is Pensioner ? 
                AddPensioner(citizen) : AddCitizen(citizen);
        }

        public void CopyTo(Array array, int index)
        {
            mCitizens.CopyTo(array, index);
        }

        public void Remove()
        {
            if (Count == 0)
                throw new Exception("collection is empty");

            Remove(mCitizens.First());
        }

        public void Remove(Citizen citizen)
        {
            int CitizenIndex = IndexOf(citizen);
            if (CitizenIndex == CitizenCollectionConstants.NotExistIndex)
                throw new ArgumentException("citizen is not exist");

            if (citizen is Pensioner)
                mLastPensionerPosition--;
            Count--;

            Array.ConstrainedCopy(mCitizens, CitizenIndex + 1, mCitizens, CitizenIndex, Count);
        }

        public bool Contains(Citizen citizen)
        {
            return mCitizens.Contains(citizen);
        }

        public void Clear()
        {
            mLastPensionerPosition = -1;
            Count = 0;
        }

        public (Citizen citizen, int numberInQueue) Last()
        {
            return (mCitizens[Count - 1], Count - 1);
        }

        public IEnumerator GetEnumerator()
        {
            return mCitizens.GetEnumerator();
        }

        public override string ToString()
        {
            return String.Join(" ", mCitizens.Take(Count));
        }
        #endregion

        #region Private methods

        private void ResizeArray()
        {
            Citizen[] newArray = new Citizen[mCitizens.Length * 
                CitizenCollectionConstants.ArraySizeMultiplier];

            mCitizens.CopyTo(newArray, 0);
            mCitizens = newArray;
        }

        private int AddPensioner(Citizen citizen)
        {
            Insert(citizen, ++mLastPensionerPosition);
            return mLastPensionerPosition;
        }

        private int AddCitizen(Citizen citizen)
        {
            mCitizens[Count - 1] = citizen;
            return Count - 1;
        }

        private void Insert(Citizen item, int position)
        {
            if (position < 0 || position >= Count)
                throw new ArgumentException(nameof(position));

            Array.ConstrainedCopy(mCitizens, position, mCitizens, position + 1, Count - position);
            mCitizens[position] = item;
        }

        private int IndexOf(Citizen citizen)
        {
            for (int i = 0; i < Count; i++)
                if (citizen.Equals(mCitizens[i]))
                    return i;

            return CitizenCollectionConstants.NotExistIndex;
        }

        #endregion
    }
}

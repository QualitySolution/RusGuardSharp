namespace rglib.wftest.Model {
    public abstract class BindingWrapper<T> {
        private T _wrappedObject;

        protected BindingWrapper(T wrappedObject) {
            _wrappedObject = wrappedObject;
        }

        public T WrappedObject {
            get { return _wrappedObject; }
        }
    }
}
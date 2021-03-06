/*
 * Copyright 2010-2017 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 * Copyright 2018- Vincent DARON All Rights Reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License").
 * You may not use this file except in compliance with the License.
 * A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 * or in the "license" file accompanying this file. This file is distributed
 * on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
 * express or implied. See the License for the specific language governing
 * permissions and limitations under the License.
 */
namespace StatesLanguage.Model.States
{
    public abstract class StateVisitor<T>
    {
        public virtual T Visit(ChoiceState choiceState)
        {
            return default(T);
        }

        public virtual T Visit(FailState failState)
        {
            return default(T);
        }

        public virtual T Visit(ParallelState parallelState)
        {
            return default(T);
        }

        public virtual T Visit(PassState passState)
        {
            return default(T);
        }

        public virtual T Visit(SucceedState succeedState)
        {
            return default(T);
        }

        public virtual T Visit(TaskState taskState)
        {
            return default(T);
        }

        public virtual T Visit(WaitState waitState)
        {
            return default(T);
        }
    }
}